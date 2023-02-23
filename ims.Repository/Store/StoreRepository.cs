using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ims.Core.Repository;
using ims.Data.Context;
using ims.Repository.Base;

namespace ims.Repository.Store
{
    public class StoreRepository : Repository<ims.Data.Entity.Store>, IStoreRepository
    {
        private EasyStockManagerDbContext dbContext { get => _context as EasyStockManagerDbContext; }

        public StoreRepository(DbContext context) : base(context)
        {
        }
    }
}
