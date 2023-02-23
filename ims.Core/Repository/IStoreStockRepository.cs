using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ims.Core.Repository
{
    public interface IStoreStockRepository : IRepository<ims.Data.Entity.StoreStock>
    {
        Task RemoveByStoreAndProductId(int productId, int storeId);
        Task<ims.Data.Entity.StoreStock> GetByStoreAndProductId(int productId, int storeId);
    }
}
