using ims.Core.Service;
using ims.Model.Domain;
using ims.Model.Service;
using ims.Model.ViewModel.Auth;
using ims.Model.ViewModel.JsonResult;
using ims.Security.ClaimTypes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ims.Web.Controllers;

public class AuthController : Controller
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken()]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        JsonResultModel jsonResultModel = new JsonResultModel();
        try
        {
            ServiceResult<UserDTO> result = _userService.Login(model.UserName, model.Password);
            if (result.IsSucceeded)
            {
                var claims = result.TransactionResult
                    .Permissions
                    .Select(p => new Claim(PermissionClaimType.Permission, $"{PermissionClaimType.Permission}.{p}"))
                    .Append(new Claim(ClaimTypes.Name, model.UserName))
                    .Append(new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()))
                    .ToList();
                claims.AddRange(result.TransactionResult.Roles.Select(r => new Claim(ClaimTypes.Role, r.RoleName)));
                var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                jsonResultModel.IsSucceeded = true;
                jsonResultModel.IsRedirect = true;
                jsonResultModel.RedirectUrl = "/home";
            }
            else
            {
                jsonResultModel.IsSucceeded = false;
                jsonResultModel.UserMessage = result.UserMessage;
            }
        }
        catch (Exception ex)
        {
            jsonResultModel.IsSucceeded = false;
            jsonResultModel.UserMessage = ex.Message;
        }
        return Json(jsonResultModel);
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("~/auth/login");
    }
}
