using AutoMapper;
using ims.Common.Message;
using ims.Core.Service;
using ims.Core.UnitOfWorks;
using ims.Model.Domain;
using ims.Model.Service;
using ims.Service.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity = ims.Data.Entity;

namespace ims.Service.Role;

public class RoleService : BaseService, IRoleService
{
    public RoleService(IUnitOfWorks unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    public async Task<ServiceResult> AddAsync(RoleDTO model)
    {
        ServiceResult result = new ServiceResult();
        try
        {
            using (_unitOfWork)
            {
                Entity.Role entity = _mapper.Map<Entity.Role>(model);
                entity.CreateDate = DateTime.Now;
                await _unitOfWork.RoleRepository.AddAsync(entity);
                await _unitOfWork.SaveAsync();
                result.Id = entity.Id;
                result.UserMessage = CommonMessages.MSG0001;
            }
        }
        catch (Exception ex)
        {
            result.IsSucceeded = false;
            result.UserMessage = ex.Message;
        }
        return result;
    }
    public async Task<ServiceResult<IEnumerable<RoleDTO>>> Find(RoleDTO criteria)
    {
        ServiceResult<IEnumerable<RoleDTO>> result = new ServiceResult<IEnumerable<RoleDTO>>();
        try
        {
            using (_unitOfWork)
            {
                IEnumerable<Entity.Role> list = await _unitOfWork
                                                            .RoleRepository
                                                            .FindAsync(filter: x => (string.IsNullOrEmpty(criteria.Name) || x.Name.Contains(criteria.Name)),
                                                                       orderByDesc: x => x.Id,
                                                                       skip: criteria.PageNumber,
                                                                       take: criteria.RecordCount);

                result.TransactionResult = _mapper.Map<IEnumerable<RoleDTO>>(list);
            }
        }
        catch (Exception ex)
        {
            result.IsSucceeded = false;
            result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
        }
        return result;
    }
    public async Task<ServiceResult<int>> FindCount(RoleDTO criteria)
    {
        ServiceResult<int> result = new ServiceResult<int>();
        try
        {
            using (_unitOfWork)
            {
                int count = await _unitOfWork.RoleRepository
                                              .FindCountAsync(filter: x => (string.IsNullOrEmpty(criteria.Name) || x.Name.Contains(criteria.Name)));

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
    public async Task<ServiceResult<IEnumerable<RoleDTO>>> GetAll()
    {
        ServiceResult<IEnumerable<RoleDTO>> result = new ServiceResult<IEnumerable<RoleDTO>>();
        try
        {
            using (_unitOfWork)
            {
                IEnumerable<Entity.Role> list = await _unitOfWork.RoleRepository.GetAllAsync();
                result.TransactionResult = _mapper.Map<IEnumerable<RoleDTO>>(list);
            }
        }
        catch (Exception ex)
        {
            result.IsSucceeded = false;
            result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
        }

        return result;
    }
    public async Task<ServiceResult<RoleDTO>> GetById(int id)
    {
        ServiceResult<RoleDTO> result = new ServiceResult<RoleDTO>();
        try
        {
            using (_unitOfWork)
            {
                Entity.Role entity = await _unitOfWork.RoleRepository.GetByIdAsync(id);
                result.TransactionResult = _mapper.Map<RoleDTO>(entity);
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
                await _unitOfWork.RoleRepository.RemoveById(id);
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
    public async Task<ServiceResult> Update(RoleDTO model)
    {
        ServiceResult result = new();
        try
        {
            using (_unitOfWork)
            {
                Entity.Role entity = await _unitOfWork.RoleRepository.GetByIdAsync(model.Id.Value);
                if (entity != null)
                {
                    _mapper.Map(model, entity);
                    _unitOfWork.RoleRepository.Update(entity);
                    await _unitOfWork.SaveAsync();
                    result.UserMessage = CommonMessages.MSG0001;
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
