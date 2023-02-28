using System.Collections.Generic;

namespace ims.Data.Entity;

public class Store : BaseEntity
{
    public string StoreName { get; set; }
    public string StoreCode { get; set; }
    public virtual ICollection<StoreStock> StoreStock { get; set; }
}
