using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ims.Core.Repository
{
    public interface IProductRepository : IRepository<ims.Data.Entity.Product>
    {
        Task DeleteProductImage(int id);
        Task<IEnumerable<ims.Data.Entity.Product>> GetProductsByBarcodeAndName(string term);
    }
}
