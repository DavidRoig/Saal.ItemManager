using Saal.ItemManager.Core.Models;

namespace Saal.ItemManager.Core.Services
{
    internal class ItemService : IItemService
    {

        private readonly IList<Item> DummyResult = new List<Item> { new Item { Name = "Dummy Name"}};

        public IList<Item> Get()
        {
            return DummyResult;
        }
        public Item Get(int id)
        {
            return DummyResult.First();
        }

        public int Create(Item item)
        {
            return (10);
        }

        public void Edit(Item item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Item item)
        {
            throw new NotImplementedException();
        }

    }
}
