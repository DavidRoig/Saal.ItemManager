using Microsoft.AspNetCore.Mvc;
using Saal.ItemManager.Core.Models;
using Saal.ItemManager.Core.Services;

namespace Saal.ItemManager.Api.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        // GET: Items
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Item>>> GetAsync() => Ok(await _itemService.GetAllAsync());

        // GET: items/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Item>> GetAsync(int id)
        {
            var result = await _itemService.GetAsync(id);

            if (result == null)
                return NotFound();

            return result;
        }

        // POST: items
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<int>> CreateAsync(ItemRequest item)
        {
            var result = await _itemService.CreateAsync(item);

            return Ok(result);
        }

        // PUT: items/{id}
        [HttpPut]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateAsync(int id, ItemRequest item)
        {
            var isItemFound = await _itemService.UpdateAsync(id, item);

            if (!isItemFound)
                return NotFound();

            return Ok();
        }

        // DELETE: items/5
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var isItemFound = await _itemService.DeleteAsync(id);

            if (!isItemFound)
                return NotFound();

            return Ok();
        }
    }
}
