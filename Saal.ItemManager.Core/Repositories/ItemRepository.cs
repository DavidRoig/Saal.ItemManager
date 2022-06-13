using Saal.ItemManager.Core.Models;

namespace Saal.ItemManager.Core.Repositories
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync();
        Task<Item?> GetAsync(int id);
        Task<int> DeleteAsync(int id);
        Task<int> SaveAsync(List<Item> itemList);
    }
}
