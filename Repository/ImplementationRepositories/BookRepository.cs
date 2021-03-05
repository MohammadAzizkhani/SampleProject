using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.AbstractionRepositories;

namespace Repository.ImplementationRepositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(AppContext context) : base(context)
        {
        }
        public AppContext AppContext => Context as AppContext;
        public async Task<IEnumerable<Book>> GetBooksWithPaginationAsync(int take, int skip)
        {
            return await AppContext.Books.Skip(skip).Take(take).Include(x => x.Category).ToListAsync();
        }
        public async Task<Book> GetBookAndBookFile(string isbn)
        {
            return await AppContext.Books.Where(x => x.ISBN == isbn).Include(b => b.BookFile).FirstOrDefaultAsync();
        }
    }
}