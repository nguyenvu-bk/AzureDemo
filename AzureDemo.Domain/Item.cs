namespace AzureDemo.Domain
{
    public class Item
    {
        public string Id { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public bool Completed { get; set; }
    }
}