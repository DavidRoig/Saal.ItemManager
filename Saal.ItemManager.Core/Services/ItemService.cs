using Saal.ItemManager.Core.Models;

namespace Saal.ItemManager.Core.Services
{
    internal class ItemService : IItemService
    {
        private readonly IList<Item> DummyResult = new List<Item> {
            new Item { Name = "Dummy Name 1", Description = "Dummy description", Type = "DummyType"},
            new Item { Name = "Dummy Name 2", Description = "Dummy description", Type = "DummyType"},
            new Item { Name = "Dummy Name 3", Description = "Dummy description", Type = "DummyType"},
            new Item { Name = "Dummy Name 4", Description = "Dummy description", Type = "DummyType"},
            new Item { Name = "Dummy Name 5", Description = "Dummy description", Type = "DummyType"},
            new Item { Name = "Dummy Name 6", Description = "Dummy description", Type = "DummyType"},
        };

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
