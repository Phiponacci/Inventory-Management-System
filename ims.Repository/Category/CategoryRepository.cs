using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ims.Core.Repository;
using ims.Data.Context;
using ims.Repository.Base;

namespace ims.Repository.Category
{
    public class CategoryRepository : Repository<ims.Data.Entity.Category>, ICategoryRepository
    {
        private EasyStockManagerDbContext dbContext { get => _context as EasyStockManagerDbContext; }

        public CategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
