using Saal.ItemManager.Core.Models;
using Saal.ItemManager.Core.Repositories;
using System.Text.Json;

namespace Saal.ItemManager.Infrastructure.Repositories
{
    /// <summary>
    /// Persistance layer which store/retrieve all the data
    /// </summary>
    public class ItemJsonRepository : IItemRepository
    {
        private const string StorageFilename = "ItemStorage.json";

        public async Task<int> DeleteAsync(int id)
        {
            var itemList = await GetAllAsync();
            var deletedRecords = itemList.RemoveAll(x => x.Id.Equals(id));

            await SaveAsync(itemList);

            return deletedRecords;
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

        public async Task<int> SaveAsync(List<Item> itemList)
        {
            var jsonString = JsonSerializer.Serialize(itemList);
            await File.WriteAllTextAsync(StorageFilename, jsonString);

            return itemList.Count(); // return amount of records inserted
        }
    }
}
