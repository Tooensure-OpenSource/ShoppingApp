using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Data.DTOs.Outgoing;

namespace ReadyApp.Api.Rest.Controllers.v1.IControllers
{
    public interface IProductController
    {
        Task<ActionResult<IEnumerable<ProductDto>>> ProductsForUser(Guid userId);
        Task<ActionResult<IEnumerable<ProductDto>>> ProductsForBusiness(Guid userId, Guid businessId);
        Task<ActionResult<ProductDto>> ProductForBusiness(Guid userId, Guid businessId, Guid productId);

    }
}