using AzureDemo.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AzureDemo.API.Controllers
{
    [Route("api/mainpage")]
    public class ItemController : Controller
    {
        private readonly ICosmosDbService _cosmosDbService;
        public ItemController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }


        [HttpGet("item/{id}")]
        public async Task<ActionResult> GetItemById(string id)
        {
            var result = await _cosmosDbService.GetItemAsync(id);

            return Ok(result);
        }

        [HttpGet("items/{query}")]
        public async Task<ActionResult> GetItems(string query)
        {
            var result = await _cosmosDbService.GetItemsAsync(query);

            return Ok(result);
        }
    }
}
