using ims.Data.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ims.Data.EqualityComparer;

public class PermissionComparer : IEqualityComparer<Permission>
{
    public bool Equals(Permission x, Permission y)
    {
        return x.Module.Equals(y.Module) && x.Operation.Equals(y.Operation);
    }

    public int GetHashCode([DisallowNull] Permission obj)
    {
        return obj.Module.GetHashCode() ^ obj.Operation.GetHashCode();
    }
}
