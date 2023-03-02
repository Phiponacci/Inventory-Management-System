using AutoMapper;
using ims.Common.Extensions;
using ims.Common.Message;
using ims.Core.Service;
using ims.Core.UnitOfWorks;
using ims.Model.Domain;
using ims.Model.Service;
using ims.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity = ims.Data.Entity;

namespace ims.Service.User;

public class UserService : BaseService, IUserService
{
    public UserService(IUnitOfWorks unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    public async Task<ServiceResult> AddAsync(UserDTO model)
    {
        ServiceResult result = new ServiceResult();
        try
        {
            using (_unitOfWork)
            {
                bool emailValidation = await _unitOfWork.UserRepository.UserNameValidationCreateUser(model.Email);

                if (!emailValidation)
                {
                    Entity.User entity = _mapper.Map<Entity.User>(model);
                    entity.Password = model.Password.HashPassword();
                    entity.CreateDate = DateTime.Now;
                    await _unitOfWork.UserRepository.AddAsync(entity);
                    await _unitOfWork.SaveAsync();
                    result.Id = entity.Id;
                    result.UserMessage = CommonMessages.MSG0001;
                }
                else
                {
                    result.IsSucceeded = false;
                    result.UserMessage = CommonMessages.MSG0003;
                }

            }
        }
        catch (Exception ex)
        {
            result.IsSucceeded = false;
            result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
        }
        return result;
    }
    public async Task<ServiceResult<IEnumerable<UserDTO>>> Find(UserDTO criteria)
    {
        ServiceResult<IEnumerable<UserDTO>> result = new ServiceResult<IEnumerable<UserDTO>>();
        try
        {
            using (_unitOfWork)
            {
                IEnumerable<Entity.User> list = await _unitOfWork
                                                            .UserRepository
                                                            .FindAsync(filter: x => (string.IsNullOrEmpty(criteria.UserName) || x.UserName.Contains(criteria.UserName)) &&
                                                                                    (string.IsNullOrEmpty(criteria.FirstName) || x.FirstName.Contains(criteria.FirstName)) &&
                                                                                    (string.IsNullOrEmpty(criteria.LastName) || x.LastName.Contains(criteria.LastName)),
                                                                       orderByDesc: x => x.Id,
                                                                       skip: criteria.PageNumber,
                                                                       take: criteria.RecordCount, includes: new[] { "Roles" });
                result.TransactionResult = _mapper.Map<IEnumerable<UserDTO>>(list);
            }
        }
        catch (Exception ex)
        {
            result.IsSucceeded = false;
            result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
        }
        return result;
    }
    public async Task<ServiceResult<int>> FindCount(UserDTO criteria)
    {
        ServiceResult<int> result = new ServiceResult<int>();
        try
        {
            using (_unitOfWork)
            {
                int count = await _unitOfWork.UserRepository
                                              .FindCountAsync(filter: x => (string.IsNullOrEmpty(criteria.Email) || x.Email.Contains(criteria.Email)) &&
                                                                           (string.IsNullOrEmpty(criteria.FirstName) || x.FirstName.Contains(criteria.FirstName)) &&
                                                                           (string.IsNullOrEmpty(criteria.LastName) || x.LastName.Contains(criteria.LastName)));

                result.TransactionResult = count;
            }
        }
        catch (Exception ex)
        {
            result.IsSucceeded = false;
            result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
        }
        return result;
    }
    public async Task<ServiceResult<IEnumerable<UserDTO>>> GetAll()
    {
        ServiceResult<IEnumerable<UserDTO>> result = new ServiceResult<IEnumerable<UserDTO>>();
        try
        {
            using (_unitOfWork)
            {
                IEnumerable<Entity.User> list = await _unitOfWork.UserRepository.GetAllAsync();
                result.TransactionResult = _mapper.Map<IEnumerable<UserDTO>>(list);
            }
        }
        catch (Exception ex)
        {
            result.IsSucceeded = false;
            result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
        }

        return result;
    }
    public async Task<ServiceResult<UserDTO>> GetById(int id)
    {
        ServiceResult<UserDTO> result = new ServiceResult<UserDTO>();
        try
        {
            using (_unitOfWork)
            {
                Entity.User entity = await _unitOfWork.UserRepository.GetByIdAsync(id);
                result.TransactionResult = _mapper.Map<UserDTO>(entity);
            }
        }
        catch (Exception ex)
        {
            result.IsSucceeded = false;
            result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
        }
        return result;
    }

    public async Task<ServiceResult<UserDTO>> GetWithRolesById(int id)
    {
        ServiceResult<UserDTO> result = new ServiceResult<UserDTO>();
        try
        {
            using (_unitOfWork)
            {
                Entity.User entity = await _unitOfWork.UserRepository.GetWithRolesByIdAsync(id);
                result.TransactionResult = _mapper.Map<UserDTO>(entity);
            }
        }
        catch (Exception ex)
        {
            result.IsSucceeded = false;
            result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
        }
        return result;
    }

    public async Task<ServiceResult<UserDTO>> GetWithRolesByUsername(string username)
    {
        ServiceResult<UserDTO> result = new ServiceResult<UserDTO>();
        try
        {
            using (_unitOfWork)
            {
                Entity.User entity = await _unitOfWork.UserRepository.GetWithRolesByUsernameAsync(username);
                result.TransactionResult = _mapper.Map<UserDTO>(entity);
            }
        }
        catch (Exception ex)
        {
            result.IsSucceeded = false;
            result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
        }
        return result;
    }

    public ServiceResult<UserDTO> Login(string userName, string password)
    {
        ServiceResult<UserDTO> result = new ServiceResult<UserDTO>();
        try
        {
            using (_unitOfWork)
            {
                Entity.User user = _unitOfWork.UserRepository.Login(userName, password.HashPassword());
                if (user != default)
                {
                    var userDTO = _mapper.Map<UserDTO>(user);
                    userDTO.Permissions = user.Roles.SelectMany(role => role.Permissions).Select(p => p.ToString()).ToList();
                    userDTO.Roles = _mapper.Map<List<RoleDTO>>(user.Roles);
                    result.IsSucceeded = true;
                    result.TransactionResult = userDTO;
                }
                else
                {
                    result.IsSucceeded = false;
                    result.UserMessage = CommonMessages.MSG0005;
                }
            }
        }
        catch (Exception ex)
        {
            result.IsSucceeded = false;
            result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
        }
        return result;
    }
    public async Task<ServiceResult> RemoveById(int id)
    {
        ServiceResult result = new ServiceResult();
        try
        {
            using (_unitOfWork)
            {
                await _unitOfWork.UserRepository.RemoveById(id);
                await _unitOfWork.SaveAsync();
                result.UserMessage = CommonMessages.MSG0001;
            }
        }
        catch (Exception ex)
        {
            result.IsSucceeded = false;
            result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
        }
        return result;
    }
    public async Task<ServiceResult> Update(UserDTO model)
    {
        ServiceResult result = new();
        try
        {
            using (_unitOfWork)
            {
                Entity.User entity = await _unitOfWork.UserRepository.GetByIdAsync(model.Id.Value);
                if (entity != null)
                {
                    bool userNameValidation = await _unitOfWork.UserRepository.UserNameValidationUpdateUser(model.UserName, model.Id.Value);

                    if (!userNameValidation)
                    {
                        _mapper.Map(model, entity);

                        if (!string.IsNullOrEmpty(model.Password))
                            entity.Password = model.Password.HashPassword();

                        _unitOfWork.UserRepository.Update(entity);

                        await _unitOfWork.SaveAsync();
                        result.UserMessage = CommonMessages.MSG0001;
                    }
                    else
                    {
                        result.IsSucceeded = false;
                        result.UserMessage = CommonMessages.MSG0003;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            result.IsSucceeded = false;
            result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
        }
        return result;
    }

}
