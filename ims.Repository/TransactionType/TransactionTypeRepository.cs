using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ims.Core.Repository;
using ims.Data.Context;
using ims.Repository.Base;

namespace ims.Repository.TransactionType
{
    public class TransactionTypeRepository : Repository<ims.Data.Entity.TransactionType>, ITransactionTypeRepository
    {
        private AppDbContext dbContext { get => _context as AppDbContext; }
        public TransactionTypeRepository(DbContext context) : base(context)
        {
        }
    }
}
