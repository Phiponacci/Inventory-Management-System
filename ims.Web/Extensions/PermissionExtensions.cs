using ims.Model.ViewModel.Permission;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace ims.Web.Extensions;

public static class PermissionExtensions
{
    public static List<PermissionViewModel> GetPermissions(this IFormCollection form)
    {
        return form
            .Where(el => el.Value == "on")
            .Select(el =>
                    new PermissionViewModel
                    {
                        Operation = el.Key.ToString().Split(".")[1],
                        Module = el.Key.ToString().Split(".")[2]
                    })
            .ToList();
    }
}
