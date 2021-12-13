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
            var business = await _unitOfWork.Businesses.Get(incomming.BusinessId);
            if(business == null) return BadRequest("Business not exist");
            
            // Verfy business contains user
            var isUser = business.Users.Any(x => x.Id == incomming.UserId);
            if(isUser.Equals(false)) return BadRequest("You can not create a business here");
            business.Products.Add(product);

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