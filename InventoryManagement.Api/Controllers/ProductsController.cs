using AutoMapper;
using InventoryManagement.Api.Dtos;
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
        private readonly IMapper _mapper;

        public ProductsController(
            IProductsService productService,
            IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto productDto)
        {
            var productModel = _mapper.Map<ProductModel>(productDto);
            var result = await _productService.CreateProductAsync(productModel);

            return Ok(_mapper.Map<ProductDto>(result));
        }
    }
}