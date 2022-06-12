namespace Saal.ItemManager.Core.Models
{
    public class Item : ItemRequest
    {
        private Item() { }

        public int Id { get; private set; }
        public List<int> Relations { get; } = new List<int>();

        internal static Item Create(ItemRequest item) => Create(item.Name, item.Description, item.Type);

        internal static Item Create(string name, string description, string type) => new Item
        {
            Id = new Random().Next(0, 1000),
            Name = name,
            Description = description,
            Type = type,
        };

        internal static void Update(Item result, ItemRequest item)
        {
            result.Name = item.Name;
            result.Description = item.Description;
            result.Type = item.Type;
        }
    }
}
