using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.ViewModel;
using ApiServices;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookController(IUnitOfWork unitOfWork
        ,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [Route("AllBooks")]
        [HttpGet]
        public async Task<IEnumerable<BookViewModel>> GetAllBooksAsync([FromQuery]int skip,[FromQuery]int take = 10)
        {
            
             return _mapper.Map<IEnumerable<BookViewModel>>(await _unitOfWork.Books.GetBooksWithPaginationAsync(take, skip));
        }
        [Route("GetBook")]
        [HttpGet]
        public  BookViewModel GetBooks([FromQuery]string isbn)
        {
            if (string.IsNullOrEmpty(isbn) || isbn.Length > 20)
            {
                Response.StatusCode = 400;
                return null;
            }
            return _mapper.Map<BookViewModel>(_unitOfWork.Books.Find(x => x.ISBN == isbn).FirstOrDefault());
        }

        [Route("AddBook")]
        [HttpPost]
        public async Task<IActionResult> AddBooksAsync([FromBody]CreateBookViewModel model)
        {
            var res = _mapper.Map<Book>(model);
            await _unitOfWork.Books.AddAsync(res);
            await _unitOfWork.Complete();
            return Ok();
        }

        [Route("UpdateBook")]
        [HttpPut]
        public async Task<IActionResult> UpdateBooksAsync([FromBody]CreateBookViewModel model)
        {
            var result = _unitOfWork.Books.Find(b=> b.ISBN == model.ISBN).FirstOrDefault();
            _mapper.Map(model, result);
            await _unitOfWork.Complete();
            return Ok();
        }


        [Route("UpdateBookState")]
        [HttpPatch]
        public async Task<IActionResult> UpdateBookStateAsync([FromQuery] string isbn , [FromBody] bool canBorrow)
        {
            if (string.IsNullOrEmpty(isbn) || isbn.Length > 20)
            {
                return BadRequest();
            }
            var result = _unitOfWork.Books.Find(b => b.ISBN == isbn).FirstOrDefault();
            result.CanBorrow = canBorrow;
            await _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteBook")]
        public async Task<IActionResult> DeleteBookAsync([FromQuery]string isbn)
        {
            if (string.IsNullOrEmpty(isbn) || isbn.Length > 20)
            {
                return BadRequest();
            }
            _unitOfWork.Books.Remove(_unitOfWork.Books.Find(u => u.ISBN == isbn).FirstOrDefault());
            await _unitOfWork.Complete();
            return Ok();
        }

        [Route("GetBookCategories")]
        [HttpGet]
        public async Task<IEnumerable<CategoryViewModel>> GetBookCategoryAsync()
        {
            return _mapper.Map<IEnumerable<CategoryViewModel>>(await _unitOfWork.Categories.GetAllAsync());
        }
    }
}