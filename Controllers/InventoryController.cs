using Microsoft.AspNetCore.Mvc;
using AdoWebApiStoreInventory.Repositories.Repositories;
using AdoWebApiStoreInventory.Repositories.Models;

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

            [HttpPost("Create")]
            public async Task<IActionResult> Create()
            {
                return new OkObjectResult(await _myRepository.Create());
            }
    }
}
