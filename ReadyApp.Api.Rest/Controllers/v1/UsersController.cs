using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadyApp.Api.Rest.Controllers.v1.IControllers;
using shoppingApp.Data.DbSet;
using shoppingApp.Data.IConfigeration;
using ShoppingApp.Data.DTOs.Outgoing;
using ShoppingApp.Data.DTOs.UserDto;

namespace ReadyApp.Api.Rest.Controllers.v1
{
    public class UsersController : BaseController<AddUserDto, UserDto>, IUserController
    {
        public UsersController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        
        // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [HttpGet("{userId}")]
        [ActionName(nameof(Get))]
        public override async Task<ActionResult<UserDto>> Get(Guid userId)
        {
            var user = await _unitOfWork.Users.Get(userId);
            var response = _mapper.Map<UserDto>(user);
            return Ok(response);
        }
        // var createdResource = new { Id = 1, Version = "1.0" };
        // var actionName = nameof(GetValue);
        // var routeValues = new { id = createdResource.Id, version = createdResource.Version };
        // return CreatedAtAction(actionName, routeValues, createdResource);
        // Location: .../api/Values/1?version=1.0
        [HttpPost]
        public override async Task<ActionResult<UserDto>> Add([FromBody] AddUserDto incomming)
        {
            var user = _mapper.Map<User>(incomming);
            
            await _unitOfWork.Users.Add(user);
            await _unitOfWork.CompleteAsync();
            
            var response = _mapper.Map<UserDto>(user);
            return CreatedAtAction(nameof(Get), new { userId = response.Id}, response);
            // return CreatedAtAction(nameof(GetUser), new {Guid = user.Id}, response);
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<UserDto>>> All()
        {
            var usersFromRepo = await _unitOfWork.Users.All();
            var users = _mapper.Map<IEnumerable<UserDto>>(usersFromRepo);
            
            return Ok(users);
        }
    }
}