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
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IEnumerable<UserViewModel>>  GetAllUsersAsync()
        {
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(await _unitOfWork.Users.GetAllAsync());
        }
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserViewModel model)
        {
            _mapper.Map(model, _unitOfWork.Users.Find(x => x.NationalCode == model.NationalCode).FirstOrDefault());
            await _unitOfWork.Complete();
            return Ok();
        }
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUserAsync([FromBody] UserViewModel model)
        {
            await _unitOfWork.Users.AddAsync(_mapper.Map<User>(model));
            await _unitOfWork.Complete();
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUserAsync([FromQuery]string nationalCode)
        {
            if (string.IsNullOrEmpty(nationalCode))
                return BadRequest();
            _unitOfWork.Users.Remove(_unitOfWork.Users.Find(u => u.NationalCode == nationalCode).FirstOrDefault());
            await _unitOfWork.Complete();
            return Ok();
        }
    }
}