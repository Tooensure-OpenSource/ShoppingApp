using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadyApp.Api.Rest.Controllers.v1.IControllers;
using shoppingApp.Data.DbSet;
using shoppingApp.Data.IConfigeration;
using ShoppingApp.Data.DTOs.UserDto;

namespace ReadyApp.Api.Rest.Controllers.v1
{
    [Route("api/users")]
    public partial class UsersController : BaseController<AddUserDto, UserDto>, IUserController
    {
        public UsersController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpPost]
        public override async Task<ActionResult<UserDto>> Add(AddUserDto incomming)
        {
            var user = _mapper.Map<User>(incomming);
            var response = _mapper.Map<UserDto>(user);
            
            await _unitOfWork.Users.Add(user);
            await _unitOfWork.CompleteAsync();
            
            return CreatedAtAction("Get", new {response.Id}, response);
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<UserDto>>> All()
        {
            var usersFromRepo = await _unitOfWork.Users.All();
            var users = _mapper.Map<IEnumerable<UserDto>>(usersFromRepo);
            
            return Ok(users);
        }

        [HttpGet("{userId}", Name = "Get")]
        [ActionName(nameof(Get))]
        public override async Task<ActionResult<UserDto>> Get(Guid userId)
        {
            var user = await _unitOfWork.Users.Get(userId);
            var response = _mapper.Map<IEnumerable<UserDto>>(user);
            return Ok(response);
        }
       
    }
}