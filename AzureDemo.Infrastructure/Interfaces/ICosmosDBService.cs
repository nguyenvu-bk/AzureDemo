using AzureDemo.Domain;

namespace AzureDemo.Infrastructure.Interfaces
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Item>> GetItemsAsync();

        Task<Item> GetItemAsync(string id);
    }
}
