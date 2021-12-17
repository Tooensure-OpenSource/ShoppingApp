using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shoppingApp.Data.IConfigeration;
namespace ReadyApp.Api.Rest.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public abstract class BaseController<Incomming, Outgoing, Query> : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public abstract Task<ActionResult<IEnumerable<Outgoing>>> All([FromQuery] Query searchQuery);
        public abstract Task<ActionResult<Outgoing>> Get(Guid id);
        public abstract Task<ActionResult<Outgoing>> Add(Incomming incomming);
    }
}