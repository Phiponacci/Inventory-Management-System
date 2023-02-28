using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ims.Core.Service;
using ims.Model.Service;
using ims.Model.ViewModel.Auth;
using ims.Model.ViewModel.JsonResult;
using ims.Model.Domain;
using ims.Model.ViewModel.Category;
using ims.Service.Category;
using AutoMapper;
using ims.Model.ViewModel.Role;

namespace ims.Web.Controllers;

public class RoleController : Controller
{
    private readonly IRoleService _roleService;
    private readonly IMapper _mapper;

    public RoleController(IRoleService roleService,
                              IMapper mapper)
    {
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
    public async Task<IActionResult> Create(CreateRoleViewModel model)
    {
        JsonResultModel jsonResultModel = new JsonResultModel();
        try
        {
            RoleDTO roleDTO = _mapper.Map<RoleDTO>(model);
            var serviceResult = await _roleService.AddAsync(roleDTO);
            jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
        }
        catch (Exception ex)
        {
            jsonResultModel.IsSucceeded = false;
            jsonResultModel.UserMessage = ex.Message;
        }
        return Json(jsonResultModel);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var serviceResult = await _roleService.GetById(id);
        EditRoleViewModel model = _mapper.Map<EditRoleViewModel>(serviceResult.TransactionResult);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken()]
    public async Task<IActionResult> Edit(EditRoleViewModel model)
    {
        JsonResultModel jsonResultModel = new JsonResultModel();
        try
        {
            RoleDTO roleDTO = _mapper.Map<RoleDTO>(model);
            var serviceResult = await _roleService.Update(roleDTO);
            jsonResultModel = _mapper.Map<JsonResultModel>(serviceResult);
            if (jsonResultModel.IsSucceeded)
            {
                jsonResultModel.IsRedirect = true;
                jsonResultModel.RedirectUrl = "/Role";
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
    public async Task<IActionResult> List(SearchRoleViewModel model)
    {
        JsonDataTableModel jsonDataTableModel = new JsonDataTableModel();
        try
        {
            RoleDTO roleDTO = _mapper.Map<RoleDTO>(model);
            ServiceResult<int> serviceCountResult = await _roleService.FindCount(roleDTO);
            ServiceResult<IEnumerable<RoleDTO>> serviceListResult = await _roleService.Find(roleDTO);

            if (serviceCountResult.IsSucceeded && serviceListResult.IsSucceeded)
            {
                List<ListRoleViewModel> listVM = _mapper.Map<List<ListRoleViewModel>>(serviceListResult.TransactionResult);
                jsonDataTableModel.aaData = listVM;
                jsonDataTableModel.iTotalDisplayRecords = serviceCountResult.TransactionResult;
                jsonDataTableModel.iTotalRecords = serviceCountResult.TransactionResult;
            }
            else
            {
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
            ServiceResult serviceResult = await _roleService.RemoveById(id);
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
