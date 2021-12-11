using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Data.DTOs.Incoming;
using ShoppingApp.Data.DTOs.Outgoing;

namespace ReadyApp.Api.Rest.Controllers.v1.IControllers
{
    public interface IOrderController
    {
        Task<ActionResult<IEnumerable<OrderDto>>> OrdersForUser(Guid userId);
        Task<ActionResult<IEnumerable<OrderDto>>> OrdersForBusiness(Guid userId, Guid businessId);
        Task<ActionResult<OrderDto>> GetOrder(Guid userId, Guid businessId, Guid orderId);
    }
}