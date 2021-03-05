using System;
using System.Threading.Tasks;
using Repository.AbstractionRepositories;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }
        ICategoryRepository Categories { get; }
        IUserRepository Users { get; }
        IBookFileRepository BookFiles { get; }
        IBorrowRepository Borrows { get; }
        Task<int> Complete();
    }
}