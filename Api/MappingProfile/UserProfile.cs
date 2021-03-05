using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.ViewModel;
using AutoMapper;
using Domain.Entities;

namespace Api.MappingProfile
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
