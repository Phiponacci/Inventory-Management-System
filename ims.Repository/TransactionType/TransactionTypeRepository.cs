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
        private EasyStockManagerDbContext dbContext { get => _context as EasyStockManagerDbContext; }
        public TransactionTypeRepository(DbContext context) : base(context)
        {
        }
    }
}
