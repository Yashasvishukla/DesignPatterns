using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace url_shorterner.Model;

public class Url
{
    public string OriginalUrl { get; set; }
    public string? DomainName { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ExpirationTime { get; set; }
    public ObjectId UserId { get; set; }
}