using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shoppingApp.Data.IConfigeration;
namespace ReadyApp.Api.Rest.Controllers.v1
{
    [ApiController]
    public abstract class BaseController<Incomming, Outgoing> : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public abstract Task<ActionResult<Outgoing>> Add(Incomming incomming);
        public abstract Task<ActionResult<IEnumerable<Outgoing>>> All();
        public abstract Task<ActionResult<Outgoing>> Get(Guid id);
        // public abstract Task<ActionResult<IEnumerable<Outgoing>>> All();
        // public abstract Task<ActionResult<IEnumerable<Outgoing>>> All(Guid id);
        // public abstract Task<ActionResult<IEnumerable<Outgoing>>> All(Guid id1, Guid id2);
        // public abstract Task<ActionResult<IEnumerable<Outgoing>>> All(Guid id1, Guid id2, Guid id3);
        // public abstract Task<ActionResult<Outgoing>> Get();
        // public abstract Task<ActionResult<Outgoing>> Get(Guid id1);
        // public abstract Task<ActionResult<Outgoing>> Get(Guid id1, Guid id2);
        // public abstract Task<ActionResult<Outgoing>> Get(Guid id1, Guid id2, Guid id3);

        // public abstract Task<ActionResult<Outgoing>> Add(Incomming incomming);
    }
}