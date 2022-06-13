using Saal.ItemManager.Core.Models;
using Saal.ItemManager.Core.Repositories;
using System.Text.Json;

namespace Saal.ItemManager.Infrastructure.Repositories
{
    public class ItemJsonRepository : IItemRepository
    {
        private const string StorageFilename = "ItemStorage.json";

        public async Task<int> CreateAsync(ItemRequest item)
        {
            var itemList = await GetAllAsync();

            var newItem = Item.Create(item);

            itemList.Add(newItem);

            await SaveAsync(itemList);

            return newItem.Id; // Return Id of the new record
        }

        public async Task<int> DeleteAsync(int id)
        {
            var itemList = await GetAllAsync();

            return itemList.RemoveAll(x => x.Id.Equals(id));
        }

        public async Task<Item?> GetAsync(int id)
        {
            var itemList = await GetAllAsync();

            return itemList.FirstOrDefault(x => x.Id.Equals(id));
        }

        public async Task<List<Item>> GetAllAsync()
        {
            var jsonString = await File.ReadAllTextAsync(StorageFilename);

            return JsonSerializer.Deserialize<List<Item>>(jsonString) ?? new List<Item>();
        }

        public async Task<bool> UpdateAsync(int id, Item item)
        {
            var itemList = await GetAllAsync();

            var index = itemList.FindIndex(x => x.Id.Equals(id));

            if (index < 0)
                return false;

            itemList[index].Name = item.Name;
            itemList[index].Description = item.Description;
            itemList[index].Type = item.Type;
            itemList[index].Relations = item.Relations;

            await SaveAsync(itemList);

            return true;
        }

        private static async Task<int> SaveAsync(List<Item> itemList)
        {
            var jsonString = JsonSerializer.Serialize(itemList);
            await File.WriteAllTextAsync(StorageFilename, jsonString);

            return itemList.Count(); // return amount of records inserted
        }
    }
}
