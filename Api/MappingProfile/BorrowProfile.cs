using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.ViewModel;
using AutoMapper;
using Domain.Entities;

namespace Api.MappingProfile
{
    public class BorrowProfile:Profile
    {
        public BorrowProfile()
        {
            CreateMap<BookBorrow, BorrowViewModel>()
                .ForMember(b => b.NationalCode, u => u.MapFrom(b => b.User.NationalCode))
                .ForMember(b => b.FatherName, u => u.MapFrom(b => b.User.FatherName))
                .ForMember(b => b.FirstName, u => u.MapFrom(b => b.User.FirstName))
                .ForMember(b => b.LastName, u => u.MapFrom(b => b.User.LastName));
            //.ReverseMap();
        }
    }
}
