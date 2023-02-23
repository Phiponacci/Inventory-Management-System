using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ims.Core.Repository
{
    public interface ITransactionRepository : IRepository<ims.Data.Entity.Transaction>
    {
        Task<ims.Data.Entity.Transaction> GetWithDetailById(int id);
        Task<ims.Data.Entity.Transaction> GetWithDetailAndProductById(int id);
    }
}
