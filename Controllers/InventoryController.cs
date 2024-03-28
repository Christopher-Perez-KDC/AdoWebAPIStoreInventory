using Microsoft.AspNetCore.Mvc;
using AdoWebApiStoreInventory.Repositories.Repositories;
using AdoWebApiStoreInventory.Repositories.Models;
using AdoWebAPIStoreInventory.RequestModels;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdoWebAPIStoreInventory.Controllers
{

    [ApiController] // what does this do ?
    [Route("[controller]")] // what does this do ?
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly InventoryRepository _myRepository;

        public InventoryController(ILogger<InventoryController> logger, InventoryRepository myRepository)
        {
            _logger = logger;
            _myRepository = myRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInventoryRequest request)
        {
            var inventoryModel = new InventoryModels
            {
                Item = request.Item,
                BrandName = request.BrandName,
                CountOnHand = request.CountOnHand,
                Location = request.Location,
                Cost = request.Cost,
            };

            return new OkObjectResult(await _myRepository.Create(inventoryModel));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllInventoryRequest getAllInventoryRequest)
        {
            var result = await _myRepository.GetAllInventories();

            return Ok(result);
        }
        [HttpGet("{InventoryId}")]
        public async Task<IActionResult> GetInventoriesById([FromRoute] GetInventoryByIDRequest request)
        {


            var result = await _myRepository.GetInventoryById(request.InventoryId);
            return Ok(result);
        }

        [HttpDelete]
        public async Task <IActionResult> DeleteInventory([FromQuery] DeleteInventoryRequest request)
        {
            var result = await _myRepository.Delete(request.InventoryId);
            return Ok(result);
        }    
    }
}


// Rest swagge example 