using Microsoft.AspNetCore.Mvc;
using Saal.ItemManager.Core.Models;
using Saal.ItemManager.Core.Services;

namespace Saal.ItemManager.Api.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService ItemService;

        public ItemController(IItemService itemService)
        {
            ItemService = itemService;
        }

        // GET: Items
        [HttpGet]
        [Route("")]
        public ActionResult<List<Item>> Get() => Ok(ItemService.Get());

        // GET: items/{id}
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Item> Get(int id)
        {
            var result = ItemService.Get(id);

            if (result == null)
                return NotFound();

            return result;
        }

        // POST: items
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult<int> Create(ItemRequest item)
        {
            var result = ItemService.Create(item);

            return Ok(result);
        }

        // PUT: items/{id}
        [HttpPut]
        //[ValidateAntiForgeryToken]
        public ActionResult Update(int id, ItemRequest item)
        {
            var isItemFound = ItemService.Update(id, item);

            if (!isItemFound)
                return NotFound();

            return Ok();
        }

        // DELETE: items/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var isItemFound = ItemService.Delete(id);

            if (!isItemFound)
                return NotFound();

            return Ok();
        }
    }
}
