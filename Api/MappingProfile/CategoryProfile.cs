using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Controllers;
using Api.ViewModel;
using AutoMapper;
using Domain.Entities;

namespace Api.MappingProfile
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
