using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ims.Data.Entity;

namespace ims.Core.Repository
{
    public interface ITransactionDetailRepository : IRepository<ims.Data.Entity.TransactionDetail>
    {
        void DeleteAllRecordByTransaction(ICollection<ims.Data.Entity.TransactionDetail> transactionDetails);
        Task<IEnumerable<ims.Data.Entity.TransactionDetail>> GetByTransactionId(int transactionId);
    }
}
