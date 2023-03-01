using ims.Data.Entity;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ims.Data.EqualityComparer;

public class IdComparer<T> : IEqualityComparer<T> where T : BaseEntity
{
    public bool Equals(T x, T y)
    {
        return x.Id.Equals(y.Id);
    }

    public int GetHashCode([DisallowNull] T obj)
    {
        return obj.Id.GetHashCode();
    }
}
