using Saal.ItemManager.Core.Models;

namespace Saal.ItemManager.Core.Repositories
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync();
        Task<Item?> GetAsync(int id);
        Task<int> CreateAsync(ItemRequest item);
        Task<bool> UpdateAsync(int id, Item item);
        Task<int> DeleteAsync(int id);
    }
}
