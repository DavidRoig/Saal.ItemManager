using Saal.ItemManager.Core.Models;

namespace Saal.ItemManager.Core.Services
{
    public interface IItemService
    {
        Item? Get(int itemId);
        List<Item> Get();
        int Create(ItemRequest item);
        bool Update(int itemId, ItemRequest item);
        bool Delete(int itemId);
        bool AddRelation(int mainItemId, int targetItemId);
        bool RemoveRelation(int mainItemId, int targetItemId);
    }
}