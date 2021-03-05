using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Repository.AbstractionRepositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooksWithPaginationAsync(int take ,int skip);
        Task<Book> GetBookAndBookFile(string isbn);
    }
}