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
        private AppDbContext dbContext { get => _context as AppDbContext; }

        public StoreRepository(DbContext context) : base(context)
        {
        }
    }
}
