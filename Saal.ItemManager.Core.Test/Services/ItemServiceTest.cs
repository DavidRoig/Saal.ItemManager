using Moq;
using Saal.ItemManager.Core.Models;
using Saal.ItemManager.Core.Repositories;
using Saal.ItemManager.Core.Services;

namespace Saal.ItemManager.Core.UnitTest.Services
{
    /// <summary>
    /// This class verify our business logic and can be extended to the whole ItemService
    /// </summary>
    [TestClass]
    public class ItemServiceTest
    {
        private readonly ItemService _itemService;
        private readonly Mock<IItemRepository> _itemRepository = new Mock<IItemRepository>();

        private static readonly int dummyItemId = 1;
        private readonly Item dummyItemRequest = new Item();
        private readonly List<Item> dummyItemList = CreateDummyItemList(dummyItemId);

        public ItemServiceTest()
        {
            _itemService = new ItemService(_itemRepository.Object);
        }

        [TestMethod]
        public async Task UpdateItem_WhenNotFound_ReturnFalseAsync()
        {
            _itemRepository
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(new List<Item>());

            var result = await _itemService.UpdateAsync(dummyItemId, dummyItemRequest);

            Assert.IsFalse(result, "ItemService Update must return false when item is not found.");
        }

        [TestMethod]
        public async Task UpdateItem_WhenNotFound_ReturnTrueAsync()
        {
            _itemRepository
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(dummyItemList);

            var result = await _itemService.UpdateAsync(dummyItemId, dummyItemRequest);

            Assert.IsTrue(result, "ItemService Update must return true when item exists.");
        }

        private static List<Item> CreateDummyItemList(int itemId)
        {
            return new List<Item> {
                new Item 
                {
                    Id = itemId,
                }
            };
        }
    }
}
