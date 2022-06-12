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

        // PUT: items/{itemId}/relations/{targetItemId}
        [HttpPut]
        [Route("{targetItemId}")]
        public ActionResult Create(int mainItemId, int targetItemId)
        {
            var success = ItemService.AddRelation(mainItemId, targetItemId);

            if (!success)
                return NotFound();

            return Ok();
        }

        // DELETE: items/{itemId}/relations/{targetItemId}
        [HttpDelete]
        [Route("{targetItemId}")]
        public ActionResult Delete(int parentItemId, int childItemId)
        {
            var isItemFound = ItemService.RemoveRelation(parentItemId, childItemId);

            if (!isItemFound)
                return NotFound();

            return Ok();
        }
    }
}
