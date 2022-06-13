using Saal.ItemManager.Core.Models;
using Saal.ItemManager.Core.Repositories;

namespace Saal.ItemManager.Core.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<List<Item>> GetAllAsync() => await _itemRepository.GetAllAsync();

        public async Task<Item?> GetAsync(int id) => await _itemRepository.GetAsync(id);

        public async Task<int> CreateAsync(ItemRequest item)
        {
            var itemId = await _itemRepository.CreateAsync(item);

            return itemId;
        }

        public async Task<bool> UpdateAsync(int id, ItemRequest item)
        {
            var result = await _itemRepository.GetAsync(id);

            if (result == null)
                return false;

            Item.Update(result, item);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var recordsDeleted = await _itemRepository.DeleteAsync(id);

            return recordsDeleted > 0;
        }

        public async Task<bool> AddRelationAsync(int mainItemId, int targetItemId)
        {
            var result = await _itemRepository.GetAsync(mainItemId); 

            if (result == null)
                return false;

            result.Relations.Add(targetItemId);

            return true;
        }

        public async Task<bool> RemoveRelationAsync(int mainItemId, int targetItemId)
        {
            var result = await _itemRepository.GetAsync(mainItemId);

            if (result == null)
                return false;

            result.Relations.RemoveAll(x => x.Equals(targetItemId));

            return true;
        }
    }
}
