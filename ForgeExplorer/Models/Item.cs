namespace ForgeExplorer.Models
{
    public class Item
    {
        public string Id { get; }
        public string Name { get; }
        public string Type { get; }
        public bool Children { get; }

        public Item(string id, string name, string type, bool children)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.Children = children;
        }
    }
}
