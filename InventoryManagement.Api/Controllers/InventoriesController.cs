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
    public class InventoriesController : ControllerBase
    {
        private readonly IInventoriesService _inventoriesService;
        private readonly IMapper _mapper;

        public InventoriesController(
            IInventoriesService inventoriesService,
            IMapper mapper)
        {
            _inventoriesService = inventoriesService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(InventoryDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<InventoryDto>> CreateInventory(CreateInventoryDto createInventoryDto)
        {
            var inventoryModel = _mapper.Map<InventoryModel>(createInventoryDto);
            var result = await _inventoriesService.CreateInventoryAsync(inventoryModel, createInventoryDto.Tags);

            return Ok(_mapper.Map<InventoryDto>(result));
        }

        [Route("/productsCountPerProduct")]
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<ProductCountModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ICollection<ProductCountModel>>> GetProductsCountPerProductByInventoryExternalId(string externalInventoryId)
        {
            var result = await _inventoriesService.GetProductsCountPerProductByInventoryExternalIdAsync(externalInventoryId);

            return Ok(result);
        }

        [Route("/productsCountPerDayPerProduct")]
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<ProductsCountForDayPerProductModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ICollection<ProductsCountForDayPerProductModel>>> GetProductsCountForDayPerProductModel()
        {
            var result = _inventoriesService.GetProductsCountPerDayPerProduct();

            return Ok(result);
        }

        [Route("/productsCountPerCompany")]
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<ProductCountModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ICollection<ProductsCountForCompanyModel>>> GetProductsCountPerCompany()
        {
            var result = _inventoriesService.GetProductsCountPerCompany();

            return Ok(result);
        }
    }
}