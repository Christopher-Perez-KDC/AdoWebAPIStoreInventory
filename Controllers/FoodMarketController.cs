using AdoWebApiStoreInventory.Repositories.Models;
using AdoWebApiStoreInventory.Repositories.Repositories;
using AdoWebAPIStoreInventory.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace AdoWebAPIStoreInventory.Controllers
{
    [ApiController]
    [Route("Market")]
    public class FoodMarketController: ControllerBase
    {
        private readonly ILogger<FoodMarketController> _logger;
        private readonly FoodMarketRepository _foodMarketRepository;

        public FoodMarketController(ILogger<FoodMarketController> logger, FoodMarketRepository foodMarketRepository)
        {
            _logger = logger;
            _foodMarketRepository = foodMarketRepository;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]FoodMarketModel request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _foodMarketRepository.Create(request);
            return CreatedAtAction(nameof(CreateFoodMarketRequest), new { id = result.FoodId }, result);
        }
    }
}
