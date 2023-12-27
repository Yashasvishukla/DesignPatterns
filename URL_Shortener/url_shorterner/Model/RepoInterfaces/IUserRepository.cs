using MongoDB.Bson;

namespace url_shorterner.Model.RepoInterfaces;

public interface IUserRepository
{
    Task<User> Get(string email);
    Task Add(User user);
    Task<bool> Remove(ObjectId userId);
    Task<bool> Update(User user);
}