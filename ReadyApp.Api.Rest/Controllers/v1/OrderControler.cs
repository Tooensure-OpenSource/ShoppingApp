using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadyApp.Api.Rest.Controllers.v1.IControllers;
using shoppingApp.Data.IConfigeration;
using ShoppingApp.Data.DTOs.Incoming;
using ShoppingApp.Data.DTOs.Outgoing;

namespace ReadyApp.Api.Rest.Controllers.v1
{
    public partial class OrderControler : BaseController<AddOrderDto, OrderDto>, IOrderController
    {
        public async Task<ActionResult<OrderDto>> GetOrder(Guid userId, Guid businessId, Guid orderId)
        {
            var orderFromRepo = await _unitOfWork.Orders.Get(userId, businessId, orderId);
            var order = _mapper.Map<OrderDto>(orderFromRepo);
            return Ok(order);
        }

        public async Task<ActionResult<IEnumerable<OrderDto>>> OrdersForBusiness(Guid userId, Guid businessId)
        {
            var ordersFromRepo = await _unitOfWork.Orders.Get(userId, businessId);
            var order = _mapper.Map<OrderDto>(ordersFromRepo);
            return Ok(order);
        }

        public async Task<ActionResult<IEnumerable<OrderDto>>> OrdersForUser(Guid userId)
        {
            var ordersFromRepo = await _unitOfWork.Orders.Get(userId);
            var order = _mapper.Map<OrderDto>(ordersFromRepo);
            return Ok(order);
        }
    }

    public partial class OrderControler : BaseController<AddOrderDto, OrderDto>, IOrderController
    {
        public OrderControler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override Task<ActionResult<OrderDto>> Add(AddOrderDto incomming)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<IEnumerable<OrderDto>>> All()
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<OrderDto>> Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}