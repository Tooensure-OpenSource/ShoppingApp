using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadyApp.Api.Rest.Controllers.v1.IControllers;
using shoppingApp.Data.DbSet;
using shoppingApp.Data.IConfigeration;
using ShoppingApp.Data.DTOs.Incoming;
using ShoppingApp.Data.DTOs.Outgoing;

namespace ReadyApp.Api.Rest.Controllers.v1
{
    public class BusinessesController : BaseController<AddBusinessDto, BusinessDto>, IBusinessController
    {
        public BusinessesController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
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
        public async override Task<ActionResult<IEnumerable<BusinessDto>>> All()
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
            var business = _mapper.Map<BusinessDto>(businessFromRepo);
            
            return Ok(business);
        }
    }
}