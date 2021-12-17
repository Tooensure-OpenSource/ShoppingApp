using AutoMapper;
using EcommerceApp.Domain.ResourceParameters.Search;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ReadyApp.Api.Rest.Controllers.v1.IControllers;
using shoppingApp.Data.DbSet;
using shoppingApp.Data.IConfigeration;
using ShoppingApp.Data.DTOs.Incoming.UpdateDto;
using ShoppingApp.Data.DTOs.Outgoing;
using ShoppingApp.Data.DTOs.UserDto;

namespace ReadyApp.Api.Rest.Controllers.v1
{
    public class UsersController : BaseController<AddUserDto, UserDto, UserSearch>, IUserController
    {
        public UsersController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        
        /// <summary>
        /// Get user by his/her id
        /// </summary>
        /// <param name="userId">The ID of the user you want to get</param>
        /// <returns>An user with ID, name and email field</returns>
        [HttpGet("{userId}")]
        [ActionName(nameof(Get))]
        public override async Task<ActionResult<UserDto>> Get(Guid userId)
        {
            var user = await _unitOfWork.Users.Get(userId);
            if (user == null) return BadRequest("User don't exist");
            var response = _mapper.Map<UserDto>(user);
            return Ok(response);
        }
        /// <summary>
        /// Create user by transfer properties
        /// </summary>
        /// <param name="incomming">There must not be another user with exact username else bad request</param>
        /// <returns>201 Status code with url in the header.</returns>
        [HttpPost]
        public override async Task<ActionResult<UserDto>> Add([FromBody] AddUserDto incomming)
        {
            // Map incoming DTO into user
            var user = _mapper.Map<User>(incomming);
            // Check if username is already taken
            var isUsername = await _unitOfWork.Users.ExistByUsername(incomming.Username);
            if (isUsername) return BadRequest("Username already exist");
            // Quite simple then add the user
            await _unitOfWork.Users.Add(user);
            // Must complete to apply changes
            await _unitOfWork.CompleteAsync();
            // Now map user into a user DTO for transfer
            var response = _mapper.Map<UserDto>(user);
            return CreatedAtAction(nameof(Get), new { userId = response.Id}, response);
            // return CreatedAtAction(nameof(GetUser), new {Guid = user.Id}, response);
        }

        [HttpGet()]
        [HttpHead]
        public override async Task<ActionResult<IEnumerable<UserDto>>> All([FromQuery] UserSearch searchQuery)
        {
            // Send search query to repo
            var usersFromRepo = await _unitOfWork.Users.Search(searchQuery);
            if(usersFromRepo.Count() <= 0) return NotFound();
            var users = _mapper.Map<IEnumerable<UserDto>>(usersFromRepo);
            return Ok(users);
        }
        

        [HttpOptions]
        
        public IActionResult GetUserOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }


        [HttpPatch("{userId}")]
        public async Task<IActionResult> UpdateForUser(Guid userId, JsonPatchDocument<UserUpdateDto> userUpdate)
        {
            // Get User by Id
            var userFromRepo = await _unitOfWork.Users.Get(userId);
            // If you don't exist, then user "Not Found" ~EXIT
            if(userFromRepo == null) return NotFound();
            // Map user being updated, copying selected property values
            var userToPath = _mapper.Map<UserUpdateDto>(userFromRepo);
            // Boom!, Then apply update to the user being updated.
            userUpdate.ApplyTo(userToPath, ModelState);
            // Validate, see if client is going against the rules
            if(!TryValidateModel(userToPath))
            {
                return ValidationProblem(ModelState);
            }
            // Map User from "Updating User" into Entity User
            // Ef-Core was tracking this User and its actions will apply these updates.
            _mapper.Map(userToPath, userFromRepo);
            // Upsert pushes these changes from Ef-Core traking
            _unitOfWork.Users.Upsert(userFromRepo);
            // Completion of task needs to be called upon task completion 
            await _unitOfWork.CompleteAsync();
            // No need to return object, only an update
            return NoContent();
        }
    }
}