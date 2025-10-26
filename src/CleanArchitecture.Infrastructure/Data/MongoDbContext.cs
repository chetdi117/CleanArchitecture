
using CleanArchitecture.Domain.Entities.Promotion;
using CleanArchitecture.Domain.Entities.User;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace CleanArchitecture.Infrastructure.Data;
public class MongoDbContext
{

    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        _database = client.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
    
    public IMongoCollection<Promotion> Promotions => _database.GetCollection<Promotion>("Promotions");
}
