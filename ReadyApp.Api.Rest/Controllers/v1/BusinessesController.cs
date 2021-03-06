using AutoMapper;
using EcommerceApp.Domain.ResourceParameters.Search;
using Microsoft.AspNetCore.Mvc;
using ReadyApp.Api.Rest.Controllers.v1.IControllers;
using shoppingApp.Data.DbSet;
using shoppingApp.Data.IConfigeration;
using ShoppingApp.Data.DTOs.Incoming;
using ShoppingApp.Data.DTOs.Outgoing;

namespace ReadyApp.Api.Rest.Controllers.v1
{
    public class BusinessesController : BaseController<AddBusinessDto, BusinessDto, BusinessSearch>, IBusinessController
    {
        public BusinessesController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        [HttpOptions()]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }

        [HttpPost]
        public override async Task<ActionResult<BusinessDto>> Add(AddBusinessDto incomming)
        {
            // get the user creating businesses
            var user = await _unitOfWork.Users.Get(incomming.UserId);
            if(user == null) return BadRequest("User do not exist");

            var business = _mapper.Map<Business>(incomming);
            // Push verified user into business
            business.Users.Add(user);
            // Adding business with user within the list should referance user
            await _unitOfWork.Businesses.Add(business);
            await _unitOfWork.CompleteAsync();

            var response = _mapper.Map<BusinessDto>(business);
            return CreatedAtAction(nameof(Get), new {businessId = response.Id}, response);
        }
        
        [HttpGet]
        public async override Task<ActionResult<IEnumerable<BusinessDto>>> All([FromQuery] BusinessSearch searchQuery)
        {
            var businessesFromRepo = await _unitOfWork.Businesses.All();
            var businesses = _mapper.Map<IEnumerable<BusinessDto>>(businessesFromRepo);
            return Ok(businesses);
        }

        [HttpGet("{businessId}")]
        [ActionName(nameof(Get))]
        public override async Task<ActionResult<BusinessDto>> Get(Guid businessId)
        {
            var businessFromRepo = await _unitOfWork.Businesses.Get(businessId);
            if(businessFromRepo == null) return BadRequest("Business don't exist");
            var business = _mapper.Map<BusinessDto>(businessFromRepo);
            
            return Ok(business);
        }

        [HttpDelete("{businessId}")]
        public async Task<ActionResult> Delete(Guid businessId)
        {
            var business = await _unitOfWork.Businesses.Get(businessId);
            if(business == null) return NotFound("No business by Id");
            // Problem
            // There is one User, with many Businesses.
            // There is one User, with many Orders.
            // There is one business, with many products,
            // There is many products, with one business,
            // Makes it diffacult because, now before deleting the business
            // 
            // _unitOfWork.Businesses.Delete(business);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

    }
}