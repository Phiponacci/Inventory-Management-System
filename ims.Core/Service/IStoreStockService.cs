using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ims.Model.Domain;
using ims.Model.Service;

namespace ims.Core.Service
{
    public interface IStoreStockService : IService<StoreStockDTO>
    {
        Task<ServiceResult<IEnumerable<StoreStockDTO>>> StoreStockReport(StoreStockDTO criteria);
    }
}
