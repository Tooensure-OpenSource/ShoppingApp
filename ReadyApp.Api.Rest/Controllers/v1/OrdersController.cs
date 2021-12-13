using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadyApp.Api.Rest.Controllers.v1.IControllers;
using shoppingApp.Data.DbSet;
using shoppingApp.Data.IConfigeration;
using ShoppingApp.Data.DbSet;
using ShoppingApp.Data.DTOs.Incoming;
using ShoppingApp.Data.DTOs.Outgoing;

namespace ReadyApp.Api.Rest.Controllers.v1
{
    public class OrdersController : BaseController<AddOrderDto, OrderDto>
    {
        public OrdersController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpPost]
        public override async Task<ActionResult<OrderDto>> Add(AddOrderDto incomming)
        {
            var orderItem = _mapper.Map<IEnumerable<OrderItem>>(incomming.Products);
            var order = _mapper.Map<Order>(incomming);
    
            // NOTE: One2Many relationship forces me to add order into
            // the user list of order first.
            // since this api design will act as a micro service.
            // the client must request order into the user first
            // var user = await _unitOfWork.Users.Get(order.UserId);
            // user.Orders.Add(order);
            // Complete
            await _unitOfWork.Orders.Add(order);
            await _unitOfWork.CompleteAsync();

            var response = _mapper.Map<OrderDto>(order);
            //TODO: configur ef core to caculate price

            return CreatedAtAction(nameof(Get), new {orderId = response.Id}, response);
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<OrderDto>>> All()
        {
            var orders = await _unitOfWork.Orders.All();
            var response = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return Ok(response);
        }

        [HttpGet("orderId")]
        [ActionName(nameof(Get))]
        public override async Task<ActionResult<OrderDto>> Get(Guid orderId)
        {
            var order = await _unitOfWork.Orders.Get(orderId);
            var response = _mapper.Map<OrderDto>(order);
            return Ok(response);
        }


    }
}
    // public partial class OrdersControler 
    // {
    //     public async Task<ActionResult<OrderDto>> GetOrder(Guid userId, Guid businessId, Guid orderId)
    //     {
    //         var orderFromRepo = await _unitOfWork.Orders.Get(userId, businessId, orderId);
    //         var order = _mapper.Map<OrderDto>(orderFromRepo);
    //         return Ok(order);
    //     }

    //     public async Task<ActionResult<IEnumerable<OrderDto>>> OrdersForBusiness(Guid userId, Guid businessId)
    //     {
    //         var ordersFromRepo = await _unitOfWork.Orders.Get(userId, businessId);
    //         var order = _mapper.Map<OrderDto>(ordersFromRepo);
    //         return Ok(order);
    //     }

    //     public async Task<ActionResult<IEnumerable<OrderDto>>> OrdersForUser(Guid userId)
    //     {
    //         var ordersFromRepo = await _unitOfWork.Orders.Get(userId);
    //         var order = _mapper.Map<OrderDto>(ordersFromRepo);
    //         return Ok(order);
    //     }
    // }
