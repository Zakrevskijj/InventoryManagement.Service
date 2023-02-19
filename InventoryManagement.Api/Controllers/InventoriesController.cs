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
        //[ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateInventory(CreateInventoryDto createInventoryDto)
        {
            var inventoryModel = _mapper.Map<InventoryModel>(createInventoryDto);
            await _inventoriesService.CreateInventoryAsync(inventoryModel, createInventoryDto.Tags);

            return Ok();
        }
    }
}