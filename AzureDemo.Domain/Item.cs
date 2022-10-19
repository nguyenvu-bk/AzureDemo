namespace AzureDemo.Domain
{
    public class Item
    {
        public string Id { get; set; } = default!;

        public string name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public bool Completed { get; set; }
    }
}