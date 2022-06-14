namespace Saal.ItemManager.Core.Models
{
    public class Item : ItemRequest
    {
        public int Id { get; set; }
        public List<int> Relations { get; set; } = new List<int>();

        public void GenerateId() => Id = new Random().Next(0, 1000);

        internal static void Update(Item result, ItemRequest item)
        {
            result.Name = item.Name;
            result.Description = item.Description;
            result.Type = item.Type;
        }
    }
}
