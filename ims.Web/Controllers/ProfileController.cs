using AutoMapper;
using ims.Core.Service;
using ims.Model.Domain;
using ims.Model.Service;
using ims.Model.ViewModel.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ims.Web.Controllers;

public class ProfileController : Controller
{

    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public ProfileController(IUserService userService,
                          IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var username = User.FindFirstValue(ClaimTypes.Name);
        var serviceResult = await _userService.GetWithRolesByUsername(username);
        ListUserViewModel model = _mapper.Map<ListUserViewModel>(serviceResult.TransactionResult);
        return View(model);
    }
}
