using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ims.Core.Repository;

namespace ims.Core.UnitOfWorks
{
    public interface IUnitOfWorks : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IStoreRepository StoreRepository { get; }
        IStoreStockRepository StoreStockRepository { get; }
        ITransactionDetailRepository TransactionDetailRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        ITransactionTypeRepository TransactionTypeRepository { get; }
        IUnitOfMeasureRepository UnitOfMeasureRepository { get; }
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        Task SaveAsync();
        void Save();
        void Commit();
        void RollBack();
        void CreateTransaction();

    }
}
