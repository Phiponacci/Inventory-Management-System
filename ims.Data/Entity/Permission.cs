using System.Collections.Generic;

namespace ims.Data.Entity;

public class Permission : BaseEntity
{
    public string Module { get; set; }

    public string Operation { get; set; }

    public override string ToString()
    {
        return $"{Module}.{Operation}";
    }
}
