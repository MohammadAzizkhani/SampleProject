using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.ViewModel;
using AutoMapper;
using Domain.Entities;

namespace Api.MappingProfile
{
    public class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookViewModel>()
                .ForMember(b=>b.Category,m=>m.MapFrom(b=>b.Category.CategoryName))
                .ForMember(b=>b.BookType, m=>m.MapFrom(b=>b.BookType.HasValue?b.BookType.Value.ToString():""))
                .ReverseMap();
        }
    }
}
