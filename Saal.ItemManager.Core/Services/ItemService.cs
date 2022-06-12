using Saal.ItemManager.Core.Models;

namespace Saal.ItemManager.Core.Services
{
    internal class ItemService : IItemService
    {
        private readonly List<Item> ItemStorage = new List<Item> {
            Item.Create("Dummy Name 1", "Dummy description", "DummyType"),
            Item.Create("Dummy Name 2", "Dummy description", "DummyType"),
        };

        public List<Item> Get() => ItemStorage;

        public Item? Get(int id) => FindItem(id);


        public int Create(ItemRequest item)
        {
            var newItem = Item.Create(item);

            ItemStorage.Add(newItem);

            return newItem.Id;
        }

        public bool Update(int id, ItemRequest item)
        {
            var result = FindItem(id);

            if (result == null)
                return false;

            Item.Update(result, item);

            return true;
        }

        public bool Delete(int id)
        {
            var recordsDeleted = ItemStorage.RemoveAll(x => x.Id.Equals(id));

            return recordsDeleted > 0;
        }

        public bool AddRelation(int mainItemId, int targetItemId)
        {
            var result = FindItem(mainItemId);

            if (result == null)
                return false;

            result.Relations.Add(targetItemId);

            return true;
        }

        public bool RemoveRelation(int mainItemId, int targetItemId)
        {
            var result = FindItem(mainItemId);

            if (result == null)
                return false;

            result.Relations.RemoveAll(x => x.Equals(targetItemId));

            return true;
        }

        private Item? FindItem(int id) => ItemStorage.FirstOrDefault(x => x.Id.Equals(id));
    }
}
