using Moq;
using Saal.ItemManager.Core.Models;
using Saal.ItemManager.Core.Repositories;
using Saal.ItemManager.Core.Services;

namespace Saal.ItemManager.Core.UnitTest.Services
{
    [TestClass]
    public class ItemServiceTest
    {
        private readonly ItemService _itemService;
        private readonly Mock<IItemRepository> _itemRepository = new Mock<IItemRepository>();

        private readonly ItemRequest dummyItemRequest = new ItemRequest();
        private readonly Item dummyItem = new Item();
        private readonly int dummyItemId = 1;

        public ItemServiceTest()
        {
            _itemService = new ItemService(_itemRepository.Object);
        }

        [TestMethod]
        public async Task UpdateItem_WhenNotFound_ReturnFalseAsync()
        {
            _itemRepository
                .Setup(x => x.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(null as Item);

            var result = await _itemService.UpdateAsync(dummyItemId, dummyItemRequest);

            Assert.IsFalse(result, "ItemService Update must return false when item is not found.");
        }

        [TestMethod]
        public async Task UpdateItem_WhenNotFound_ReturnTrueAsync()
        {
            _itemRepository
                .Setup(x => x.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(dummyItem as Item);

            var result = await _itemService.UpdateAsync(dummyItemId, dummyItemRequest);

            Assert.IsTrue(result, "ItemService Update must return true when item exists.");
        }
    }
}
