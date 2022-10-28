using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using AzureDemo.Infrastructure.Implements;
using AzureDemo.Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Connect to CosmosDB
builder.Services.AddSingleton<ICosmosDbService>(InitializeCosmosClientInstanceAsync(builder.Configuration.GetSection("KeyVault")).GetAwaiter().GetResult());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(options => options.AllowAnyOrigin());

app.Run();


static async Task<CosmosDbService> InitializeCosmosClientInstanceAsync(IConfigurationSection configurationSection)
{
    var keyVaultName = configurationSection.GetSection("KeyVaultName").Value;
    var kvUri = $"https://{keyVaultName}.vault.azure.net";

    var client1 = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

    var database1 = await client1.GetSecretAsync("DatabaseName");
    var container1 = await client1.GetSecretAsync("ContainerName");
    var account1 = await client1.GetSecretAsync("Account");
    var key1 = await client1.GetSecretAsync("Key");


    string databaseName = database1.Value.Value;
    string containerName = container1.Value.Value;
    string account = account1.Value.Value;
    string key = key1.Value.Value;
    Microsoft.Azure.Cosmos.CosmosClient client = new Microsoft.Azure.Cosmos.CosmosClient(account, key);
    CosmosDbService cosmosDbService = new CosmosDbService(client, databaseName, containerName);
    Microsoft.Azure.Cosmos.DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
    await database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");

    return cosmosDbService;
}
