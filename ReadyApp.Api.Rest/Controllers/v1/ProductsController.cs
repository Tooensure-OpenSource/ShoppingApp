using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadyApp.Api.Rest.Controllers.v1.IControllers;
using shoppingApp.Data.DbSet;
using shoppingApp.Data.IConfigeration;
using ShoppingApp.Data.DTOs.Incoming;
using ShoppingApp.Data.DTOs.Outgoing;

namespace ReadyApp.Api.Rest.Controllers.v1
{
    public class ProductsController : BaseController<AddProductDto, ProductDto>, IProductController
    {
        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpPost]
        public override async Task<ActionResult<ProductDto>> Add(AddProductDto incomming)
        {
            var product = _mapper.Map<Product>(incomming);

            // Verify business exist
            var isUserOfBusiness = await _unitOfWork.Products.IsUserOfBusiness(incomming.UserId, incomming.BusinessId);
            if(!isUserOfBusiness) return BadRequest("Not arthorized");

            await _unitOfWork.Products.Add(product);
            await _unitOfWork.CompleteAsync();
            var outgoing = _mapper.Map<ProductDto>(product);

            return CreatedAtAction(nameof(Get), new {productId = outgoing.Id}, outgoing);
        }

        [HttpGet]
        public async override Task<ActionResult<IEnumerable<ProductDto>>> All()
        {
            var products = await _unitOfWork.Products.All();
            var response = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(response);  
        }

        [HttpGet("{productId}")]
        [ActionName(nameof(Get))]
        public override async Task<ActionResult<ProductDto>> Get(Guid productId)
        {
            try
            {
                var product = await _unitOfWork.Products.Get(productId) ?? null;
                var response = _mapper.Map<ProductDto>(product);
                return Ok(response);
            }
            catch (System.Exception)
            {
                
                return BadRequest("This is actually suppose to be a bad entity proccess");
            }
        }
    }
}