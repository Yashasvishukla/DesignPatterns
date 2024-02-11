using System.Text.Json.Serialization;

namespace Infra.LegoModels;

public class Tag
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    
    // One tag can be assigned to multiple bricks
    [JsonIgnore]
    public List<Brick> Bricks { get; set; } = new List<Brick>();
}