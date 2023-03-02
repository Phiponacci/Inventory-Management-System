using ims.Common.Enums;
using ims.Data.Entity;
using ims.Security.Enums;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ims.Data.Constants;

public static class Permissions
{
    public static readonly List<Permission> AllPermissions = Module.GetValues()
                                .SelectMany((module, m) =>
                                Operation.GetValues().Select((op, o) =>
                                new Permission
                                {
                                    Id = m * Operation.GetValues().Count + o + 1,
                                    Module = module,
                                    Operation = op
                                }))
                                .ToList();
}
