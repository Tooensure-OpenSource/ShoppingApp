using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadyApp.Api.Rest.Controllers.v1.IControllers;
using shoppingApp.Data.DbSet;
using shoppingApp.Data.IConfigeration;
using ShoppingApp.Data.DTOs.Incoming;
using ShoppingApp.Data.DTOs.Outgoing;

namespace ReadyApp.Api.Rest.Controllers.v1
{
    public class BusinessController : BaseController<AddBusinessDto, BusinessDto>, IBusinessController
    {
        public BusinessController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async override Task<ActionResult<BusinessDto>> Add(AddBusinessDto incomming)
        {
            var business = _mapper.Map<Business>(incomming);
            
            await _unitOfWork.Businesses.Add(business);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        public async override Task<ActionResult<IEnumerable<BusinessDto>>> All()
        {
            var businessesFromRepo = await _unitOfWork.Businesses.All();
            var businesses = _mapper.Map<IEnumerable<BusinessDto>>(businessesFromRepo);
            return Ok(businesses);
        }

        public async override Task<ActionResult<BusinessDto>> Get(Guid businessId)
        {
            var businessFromRepo = await _unitOfWork.Businesses.Get(businessId);
            var business = _mapper.Map<BusinessDto>(businessFromRepo);
            return Ok(business);
        }
    }
}