using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.AbstractionRepositories;

namespace Repository.ImplementationRepositories
{
    public class CategoryRepository: Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(AppContext context) : base(context)
        {
        }
    }
}
