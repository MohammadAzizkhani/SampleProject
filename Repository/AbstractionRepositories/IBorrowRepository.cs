using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Repository.AbstractionRepositories
{
    public interface IBorrowRepository:IRepository<BookBorrow>
    {
        IEnumerable<BookBorrow> GetBookBorrowsByUserId(int id);
    }
}
