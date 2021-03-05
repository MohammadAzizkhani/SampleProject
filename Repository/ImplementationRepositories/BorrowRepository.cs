using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.AbstractionRepositories;

namespace Repository.ImplementationRepositories
{
    public class BorrowRepository:Repository<BookBorrow>,IBorrowRepository
    {
        public BorrowRepository(AppContext context) : base(context)
        {
        }
        public AppContext AppContext => Context as AppContext;

        public IEnumerable<BookBorrow> GetBookBorrowsByUserId(int id)
        {
            return AppContext.Borrows.Where(b => b.UserId == id).Include(b => b.Book);
        }
    }
}
