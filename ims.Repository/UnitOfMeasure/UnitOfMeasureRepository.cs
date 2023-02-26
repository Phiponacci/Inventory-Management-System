using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ims.Core.Repository;
using ims.Data.Context;
using ims.Repository.Base;

namespace ims.Repository.UnitOfMeasure
{
    public class UnitOfMeasureRepository : Repository<ims.Data.Entity.UnitOfMeasure>, IUnitOfMeasureRepository
    {
        private AppDbContext dbContext { get => _context as AppDbContext; }
        public UnitOfMeasureRepository(DbContext context) : base(context)
        {
        }
    }
}
