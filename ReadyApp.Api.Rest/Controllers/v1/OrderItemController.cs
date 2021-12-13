using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shoppingApp.Data.IConfigeration;
using ShoppingApp.Data.DbSet;
using ShoppingApp.Data.DTOs.Incoming;
using ShoppingApp.Data.DTOs.Outgoing;

namespace ReadyApp.Api.Rest.Controllers.v1
{
    public class OrderItemController : BaseController<AddOrderItemDto, OrderItemDto>
    {
        public OrderItemController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        [HttpPost]
        public async override Task<ActionResult<OrderItemDto>> Add(AddOrderItemDto incomming)
        {
            var orderItem = _mapper.Map<OrderItem>(incomming);

            // Verify that user of order item exist

            // Add orderItem to db
            await _unitOfWork.OrderItems.Add(orderItem);
            await _unitOfWork.CompleteAsync();

            var response = _mapper.Map<OrderItemDto>(orderItem);
            
            return CreatedAtAction(nameof(Get), new {orderItemId = orderItem.Id}, response);
        }

        public async override Task<ActionResult<IEnumerable<OrderItemDto>>> All()
        {
            var orderItemsFromRepo = await _unitOfWork.OrderItems.All();
            var orderItems = _mapper.Map<IEnumerable<OrderItemDto>>(orderItemsFromRepo);
            return Ok(orderItems);
        }

        [HttpGet("{orderItemId}")]
        [ActionName(nameof(Get))]
        public async override Task<ActionResult<OrderItemDto>> Get(Guid orderItemId)
        {
            var orderItemFromRepo = await _unitOfWork.OrderItems.Get(orderItemId);
            var orderItem = _mapper.Map<OrderItemDto>(orderItemFromRepo);
            return Ok(orderItem);
        }
    }
}