using MongoDB.Bson;
using MongoDB.Driver;
using url_shorterner.Context;
using url_shorterner.Model;
using url_shorterner.Model.RepoInterfaces;

namespace url_shorterner.Repository;

public class UserRepository: IUserRepository
{

    private readonly string _databaseName;
    private readonly string _connectionString;
    private readonly IMongoCollection<User> _userCollection;

    public UserRepository(IConfiguration configuration)
    {
        _databaseName = configuration.GetConnectionString("DatabaseName");
        _connectionString = configuration.GetConnectionString("DBConnection");
        MongoClientContext.ConnectionString = _connectionString;
        var mongoClient = MongoClientContext.Instance;
        Console.WriteLine($"MongoClient Instance :--- {mongoClient}");
        _userCollection = mongoClient.GetDatabase(_databaseName).GetCollection<User>(DBCollections.UserCollection.ToString());
    }

    public async Task<User> Get(string email)
    {
        var findFilter = Builders<User>.Filter.Eq("Email", email);
        var user = await _userCollection.FindAsync(findFilter);
        return user.FirstOrDefault();
    }
    
    public async Task Add(User user)
    { 
        await _userCollection.InsertOneAsync(user);
    }

    public async Task<bool> Remove(ObjectId userId)
    {
        var deleteFilter = Builders<User>.Filter.Eq("_id", userId);
        var removeResult = await _userCollection.DeleteOneAsync(deleteFilter);
        return removeResult.DeletedCount > 0;
    }

    public async Task<bool> Update(User user)
    {
        // TODO: Revisit to change for the id instead of email and implementation

        return true;
    }
}