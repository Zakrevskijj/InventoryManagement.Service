using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InventoryManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProducts()
        {
            var products = await _productService.GetProductList();

            //mapping here

            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ProductModel>> CreateProduct(ProductCreateModel request)
        {
            var result = await _productService.CreateProduct(request);

            //mapping here

            return Ok(result);
        }
    }
}