using Saal.ItemManager.Core.Models;

namespace Saal.ItemManager.Core.Repositories
{
    // Repository class is on Core to make easier the implementation of different persistance layers like Database, Apiclient, etc...
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync();
        Task<Item?> GetAsync(int id);
        Task<int> DeleteAsync(int id);
        Task<int> SaveAsync(List<Item> itemList);
    }
}
