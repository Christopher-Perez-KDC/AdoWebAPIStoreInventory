using Microsoft.AspNetCore.Mvc;
using AdoWebApiStoreInventory.Repositories.Repositories;
using AdoWebApiStoreInventory.Repositories.Models;
using AdoWebAPIStoreInventory.RequestModels;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;

namespace AdoWebAPIStoreInventory.Controllers
{

    [ApiController] 
    [Route("Inventory")] 
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly InventoryRepository _myRepository;

        public InventoryController(ILogger<InventoryController> logger, InventoryRepository myRepository)
        {
            _logger = logger;
            _myRepository = myRepository;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateInventoryRequest request)
        {
            var inventoryModel = new InventoryModels
            {
                Item = request.Item,
                Brand = request.Brand,
                CountOnHand = request.CountOnHand,
                Location = request.Location,
                Cost = request.Cost,
            };

            return new OkObjectResult(await _myRepository.Create(inventoryModel));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateInventory([FromBody] UpdateInventoryRequest request)
        {
            var inventoryModels = new InventoryModels
            {
                InventoryId = request.InventoryId,
                Item = request.Item,
                Brand = request.Brand,
                CountOnHand = request.CountOnHand,
                Location = request.Location,
                Cost = request.Cost
            };
            
            var result = await _myRepository.Update(inventoryModels);
            return Ok(result);
        }


        [HttpGet("GetAllInventory")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _myRepository.GetAllInventories();

            return Ok(result);
        }
        [HttpGet("GetInventoryByID/{InventoryId}")]
        public async Task<IActionResult> GetInventoriesById([FromRoute] GetInventoryByIDRequest request)
        {


            var result = await _myRepository.GetInventoryById(request.InventoryId);
            return Ok(result);
        }

        [HttpDelete("DeleteID")]
        public async Task <IActionResult> DeleteInventory([FromQuery] DeleteInventoryRequest request)
        {
            var result = await _myRepository.Delete(request.InventoryId);
            return Ok(result);
        }    

    }
}

