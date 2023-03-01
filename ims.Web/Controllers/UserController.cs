using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ims.Core.Service;
using ims.Model.Domain;
using ims.Model.Service;
using ims.Model.ViewModel.JsonResult;
using ims.Model.ViewModel.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using ims.Service.Store;

namespace ims.Web.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService,
                          IRoleService roleService,
                          IMapper mapper)
    {
        _userService = userService;
        _roleService = roleService;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken()]
    public async Task<IActionResult> Create(CreateUserViewModel model)
    {
        JsonResultModel jsonResultModel = new JsonResultModel();
        try
        {
            UserDTO userDTO = _mapper.Map<UserDTO>(model);
            var serviceResult = await _userService.AddAsync(userDTO);
            jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
        }
        catch (Exception ex)
        {
            jsonResultModel.IsSucceeded = false;
            jsonResultModel.UserMessage = ex.Message;
        }
        return Json(jsonResultModel);
    }

    private async Task<IEnumerable<SelectListItem>> GetRoleList()
    {
        ServiceResult<IEnumerable<RoleDTO>> serviceResult = await _roleService.GetAll();
        IEnumerable<SelectListItem> drpRoleList = _mapper.Map<IEnumerable<SelectListItem>>(serviceResult.TransactionResult);
        return drpRoleList;
    }

    //[HasPermission(Operation.UPDATE, Module.User)]
    public async Task<IActionResult> Edit(int id)
    {
        var serviceResult = await _userService.GetWithRolesById(id);
        EditUserViewModel model = _mapper.Map<EditUserViewModel>(serviceResult.TransactionResult);
        model.RoleList = await GetRoleList();
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken()]
    public async Task<IActionResult> Edit(EditUserViewModel model)
    {
        JsonResultModel jsonResultModel = new JsonResultModel();
        try
        {
            UserDTO userDTO = _mapper.Map<UserDTO>(model);
            var serviceResult = await _userService.Update(userDTO);
            jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
            if (jsonResultModel.IsSucceeded)
            {
                jsonResultModel.IsRedirect = true;
                jsonResultModel.RedirectUrl = "/User";
            }
        }
        catch (Exception ex)
        {
            jsonResultModel.IsSucceeded = false;
            jsonResultModel.UserMessage = ex.Message;
        }
        return Json(jsonResultModel);
    }


    [HttpGet]
    public async Task<IActionResult> List(SearchUserViewModel model)
    {
        JsonDataTableModel jsonDataTableModel = new JsonDataTableModel();
        try
        {
            UserDTO userDTO = _mapper.Map<UserDTO>(model);
            ServiceResult<int> serviceCountResult = await _userService.FindCount(userDTO);
            ServiceResult<IEnumerable<UserDTO>> serviceListResult = await _userService.Find(userDTO);

            if (serviceCountResult.IsSucceeded && serviceListResult.IsSucceeded)
            {
                List<ListUserViewModel> listVM = _mapper.Map<List<ListUserViewModel>>(serviceListResult.TransactionResult);
                jsonDataTableModel.aaData = listVM;
                jsonDataTableModel.iTotalDisplayRecords = serviceCountResult.TransactionResult;
                jsonDataTableModel.iTotalRecords = serviceCountResult.TransactionResult;
            }
            else
            {
                Console.WriteLine("check");
                jsonDataTableModel.IsSucceeded = false;
                jsonDataTableModel.UserMessage = serviceCountResult.UserMessage + "-" + serviceListResult.UserMessage;
            }
        }
        catch (Exception ex)
        {
            jsonDataTableModel.IsSucceeded = false;
            jsonDataTableModel.UserMessage = ex.Message;
        }

        return Json(jsonDataTableModel);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        JsonResultModel jsonResultModel = new JsonResultModel();
        try
        {
            ServiceResult serviceResult = await _userService.RemoveById(id);
            jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
        }
        catch (Exception ex)
        {
            jsonResultModel.IsSucceeded = false;
            jsonResultModel.UserMessage = ex.Message;
        }
        return Json(jsonResultModel);
    }

}
