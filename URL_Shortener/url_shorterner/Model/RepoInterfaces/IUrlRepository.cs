using MongoDB.Bson;

namespace url_shorterner.Model.RepoInterfaces;

public interface IUrlRepository
{
    Task<string> Create(Url url);
    Task<bool> Remove(ObjectId urlId);
    Task<bool> Update(Url url);
}