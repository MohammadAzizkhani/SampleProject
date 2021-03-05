using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Repository.AbstractionRepositories;
using Repository.ImplementationRepositories;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppContext _context;

        public UnitOfWork(AppContext context,
            IBookRepository bookRepository,
            ICategoryRepository categoryRepository,
            IUserRepository users,
            IBorrowRepository borrows,
            IBookFileRepository bookFileRepository)
        {
            _context = context;
            BookFiles = bookFileRepository;
            Books = bookRepository;
            Categories = categoryRepository;
            Users = users;
            Borrows = borrows;
        }

        //public ICourseRepository Courses { get; private set; }
        public IBookRepository Books { get; }
        public ICategoryRepository Categories { get; }
        public IUserRepository Users { get; }
        public IBookFileRepository BookFiles { get; }
        public IBorrowRepository Borrows { get; }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}