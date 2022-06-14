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

        public async Task<Item> CreateAsync(Item newItem)
        {
            var itemList = await _itemRepository.GetAllAsync();

            newItem.GenerateId(); // This ID is created manually but is suppose to be done by DB
            itemList.Add(newItem);

            await _itemRepository.SaveAsync(itemList);

            return newItem;
        }

        public async Task<bool> UpdateAsync(int id, ItemRequest item)
        {
            var itemList = await _itemRepository.GetAllAsync();

            var index = itemList.FindIndex(x => x.Id.Equals(id));
            if (index < 0)
                return false;

            Item.Update(itemList[index], item);
            await _itemRepository.SaveAsync(itemList);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var recordsDeleted = await _itemRepository.DeleteAsync(id);

            return recordsDeleted > 0;
        }

        public async Task<bool> AddRelationAsync(int mainItemId, int targetItemId)
        {
            var itemList = await _itemRepository.GetAllAsync();

            var index = itemList.FindIndex(x => x.Id.Equals(mainItemId));
            if (index < 0)
                return false;

            itemList[index].Relations.Add(targetItemId);
            await _itemRepository.SaveAsync(itemList);

            return true;
        }

        public async Task<bool> RemoveRelationAsync(int mainItemId, int targetItemId)
        {
            var itemList = await _itemRepository.GetAllAsync();

            var index = itemList.FindIndex(x => x.Id.Equals(mainItemId));
            if (index < 0)
                return false;

            itemList[index].Relations.RemoveAll(x => x.Equals(targetItemId));
            await _itemRepository.SaveAsync(itemList);

            return true;
        }
    }
}
