using AutoMapper;
using EcommerceApp.Domain.ResourceParameters.Search;
using Microsoft.AspNetCore.Mvc;
using ReadyApp.Api.Rest.Controllers.v1.IControllers;
using shoppingApp.Data.DbSet;
using shoppingApp.Data.IConfigeration;
using ShoppingApp.Data.DbSet;
using ShoppingApp.Data.DTOs.Incoming;
using ShoppingApp.Data.DTOs.Outgoing;

namespace ReadyApp.Api.Rest.Controllers.v1
{
    public class OrdersController : BaseController<AddOrderDto, OrderDto, OrderSearch>
    {
        public OrdersController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpPost]
        public override async Task<ActionResult<OrderDto>> Add(AddOrderDto incomming)
        {
            // See if user with Id infact exist
            var isUser = await _unitOfWork.Users.Exist(incomming.UserId);
            if(!isUser) BadRequest("User don't exist");

            // Mapping a list of AddOrderItemsDto into OrderItems 
            var orderItems = _mapper.Map<IEnumerable<AddOrderItemDto>>(incomming.orderItems);
            // Mapping the incoming object to order
            var order = _mapper.Map<Order>(incomming);
            // Checking if products ordering is part of the business products
            // cause product can't be ordered if the business don't contain the product
            foreach (var orderItemAdding in orderItems)
            {
                // Map AddOderItem into a actual order Item
                var orderItem = _mapper.Map<OrderItem>(orderItemAdding);
                // Just checking seeing if IsProductOfBusiness is true
                var isProductOfBusiness = await _unitOfWork.Products.IsProductOfBusiness(orderItemAdding.ProductId, incomming.BusinessId);
                if(!isProductOfBusiness) return BadRequest("Can't process order");
                // When I Call get() product, if include businesses is specified, I may be able to
                // NOTE: Make sure 
                var product = await _unitOfWork.Products.Get(orderItemAdding.ProductId);
                if(product == null) return BadRequest("Can't process order");
                // Add products into order item befor adding to order
                orderItem.Products.Add(product);
                order.OrderItems.Add(orderItem);
            }

        

            await _unitOfWork.Orders.Add(order);
            await _unitOfWork.CompleteAsync();

            var response = _mapper.Map<OrderDto>(order);
            //TODO: configur ef core to caculate price

            return CreatedAtAction(nameof(Get), new {orderId = response.Id}, response);
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<OrderDto>>> All([FromQuery] OrderSearch searchQuery)
        {
            var orders = await _unitOfWork.Orders.All();
            var response = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return Ok(response);
        }

        [HttpGet("{orderId}")]
        [ActionName(nameof(Get))]
        public override async Task<ActionResult<OrderDto>> Get(Guid orderId)
        {
            var order = await _unitOfWork.Orders.Get(orderId);
            if(order == null) return BadRequest("Order don't exist");
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
