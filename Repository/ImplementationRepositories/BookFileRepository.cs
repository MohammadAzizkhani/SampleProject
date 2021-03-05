using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.AbstractionRepositories;

namespace Repository.ImplementationRepositories
{
    public class BookFileRepository:Repository<BookFile>,IBookFileRepository
    {
        public BookFileRepository(AppContext context) : base(context)
        {
        }
    }
}
