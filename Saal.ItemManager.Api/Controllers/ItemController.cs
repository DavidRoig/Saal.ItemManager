using Microsoft.AspNetCore.Mvc;
using Saal.ItemManager.Core.Models;
using Saal.ItemManager.Core.Services;

namespace Saal.ItemManager.Api.Controllers
{
    [ApiController]
    [Route("Items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService ItemPersister;

        public ItemController(IItemService itemPersister)
        {
            ItemPersister = itemPersister;
        }

        //GET: ItemController/Details/5
        [HttpGet]
        public Item Get(int id)
        {
            return ItemPersister.Get(id);
        }

        //[HttpGet]
        //public IList<Item> Get()
        //{
        //    return ItemPersister.Get();
        //}

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create()
        {
            return Ok();
        }

        // POST: ItemController/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, IFormCollection collection)
        {
            return Ok();
        }

        // GET: ItemController/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
