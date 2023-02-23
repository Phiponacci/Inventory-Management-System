using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ims.Model.Domain;
using ims.Model.Service;

namespace ims.Core.Service
{
    public interface IProductService : IService<ProductDTO>
    {
        Task<ServiceResult> DeleteProductImage(int id);
        Task<ServiceResult<IEnumerable<ProductDTO>>> GetProductsByBarcodeAndName(string term);
    }
}
