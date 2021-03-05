using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.AbstractionRepositories;

namespace Repository.ImplementationRepositories
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        public UserRepository(AppContext context) : base(context)
        {
        }
    }
}
