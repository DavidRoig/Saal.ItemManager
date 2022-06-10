using Saal.ItemManager.Core.Models;

namespace Saal.ItemManager.Core.Services
{
    public interface IItemService
    {
        Item Get(int id);
        IList<Item> Get();
        int Create(Item item);
        void Delete(Item item);
        void Edit(Item item);
    }
}