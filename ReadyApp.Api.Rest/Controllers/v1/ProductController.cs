using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadyApp.Api.Rest.Controllers.v1.IControllers;
using shoppingApp.Data.DbSet;
using shoppingApp.Data.IConfigeration;
using ShoppingApp.Data.DTOs.Incoming;
using ShoppingApp.Data.DTOs.Outgoing;

namespace ReadyApp.Api.Rest.Controllers.v1
{
    public class ProductController : BaseController<AddProductDto, ProductDto>, IProductController
    {
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async override Task<ActionResult<ProductDto>> Add(AddProductDto incomming)
        {
            var product = _mapper.Map<Product>(incomming);
            var outgoing = _mapper.Map<ProductDto>(product);

            await _unitOfWork.Products.Add(product);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        public async override Task<ActionResult<IEnumerable<ProductDto>>> All()
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<ProductDto>> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<ProductDto>> ProductForBusiness(Guid userId, Guid businessId, Guid productId)
        {
            var productFromRepo = await _unitOfWork.Products.Get(userId, businessId, productId);
            var products = _mapper.Map<ProductDto>(productFromRepo);
            return Ok(products);
        }

        public async Task<ActionResult<IEnumerable<ProductDto>>> ProductsForBusiness(Guid userId, Guid businessId)
        {
            var productsFromRepo = await _unitOfWork.Products.ProductsForBusiness(userId, businessId);
            var products = _mapper.Map<IEnumerable<ProductDto>>(productsFromRepo);
            return Ok(products);
        }

        public Task<ActionResult<IEnumerable<ProductDto>>> ProductsForUser(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}