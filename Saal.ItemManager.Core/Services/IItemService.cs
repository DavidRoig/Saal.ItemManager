﻿using Saal.ItemManager.Core.Models;

namespace Saal.ItemManager.Core.Services
{
    public interface IItemService
    {
        Task<Item?> GetAsync(int itemId);
        Task<List<Item>> GetAllAsync();
        Task<Item> CreateAsync(ItemRequest item);
        Task<bool> UpdateAsync(int itemId, ItemRequest item);
        Task<bool> DeleteAsync(int itemId);
        Task<bool> AddRelationAsync(int mainItemId, int targetItemId);
        Task<bool> RemoveRelationAsync(int mainItemId, int targetItemId);
    }
}