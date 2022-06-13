using Microsoft.AspNetCore.Mvc;
using Saal.ItemManager.Core.Models;
using Saal.ItemManager.Core.Services;

namespace Saal.ItemManager.Api.Controllers
{
    [ApiController]
    [Route("items/{mainItemId}/relations")]
    public class ItemRelationController : ControllerBase
    {
        private readonly IItemService ItemService;

        public ItemRelationController(IItemService itemService)
        {
            ItemService = itemService;
        }

        // PUT: items/{mainItemId}/relations/{targetItemId}
        [HttpPut]
        [Route("{targetItemId}")]
        public async Task<ActionResult> CreateAsync(int mainItemId, int targetItemId)
        {
            var success = await ItemService.AddRelationAsync(mainItemId, targetItemId);

            if (!success)
                return NotFound();

            return Ok();
        }

        // PUT: items/{mainItemId}/relations/{targetItemId}
        [HttpDelete]
        [Route("{targetItemId}")]
        public async Task<ActionResult> DeleteAsync(int mainItemId, int targetItemId)
        {
            var isItemFound = await ItemService.RemoveRelationAsync(mainItemId, targetItemId);

            if (!isItemFound)
                return NotFound();

            return Ok();
        }
    }
}
