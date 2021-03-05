using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.ViewModel;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BorrowsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("AddBorrow")]
        public async Task<IActionResult> AddUserAsync([FromQuery] string nationalCode, [FromQuery] string isbn)
        {
            var book = _unitOfWork.Books.Find(b => b.ISBN == isbn).FirstOrDefault();
            var user = _unitOfWork.Users.Find(u => u.NationalCode == nationalCode).FirstOrDefault();
            if (book == null || !book.CanBorrow || user == null)
                return NotFound();
            var borrow = new BookBorrow
            {
                Book = book,
                User = user,
                ReturnDateTime = DateTime.Today.AddDays(14)
            };
            await _unitOfWork.Borrows.AddAsync(borrow);
            await _unitOfWork.Complete();
            return Ok();
        }


        [HttpGet]
        [Route("GetBorrows")]
        public BorrowViewModel GetBorrowsByNationalCode([FromQuery] string nationalCode)
        {
            var user = _unitOfWork.Users.Find(u => u.NationalCode == nationalCode).FirstOrDefault();
            if (user == null)
            {
                Response.StatusCode = 400;
                return null;
            }
            var model = _unitOfWork.Borrows.GetBookBorrowsByUserId(user.Id);
            var result = new BorrowViewModel
            {
                FatherName = user.FatherName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                NationalCode = user.NationalCode
            };
            var list = new List<BookViewModel>();
            foreach (var bookBorrow in model)
            {
                list.Add(_mapper.Map<Book, BookViewModel>(bookBorrow.Book));
            }

            result.Books = list;
            return result;
        }
    }
}