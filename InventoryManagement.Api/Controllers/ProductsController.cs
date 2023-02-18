using InventoryManagement.Application.Interfaces;
using InventoryManagement.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InventoryManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productService;

        public ProductsController(IProductsService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ProductModel>> CreateProduct(ProductCreateModel request)
        {
            var result = await _productService.CreateProduct(request);

            return Ok(result);
        }
    }
}