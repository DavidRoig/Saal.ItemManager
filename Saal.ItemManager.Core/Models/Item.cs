namespace Saal.ItemManager.Core.Models
{
    public class Item : ItemRequest
    {
        public int Id { get; set; }
        public List<int> Relations { get; set; } = new List<int>();

        public static Item Create(ItemRequest item) => Create(item.Name, item.Description, item.Type);

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
