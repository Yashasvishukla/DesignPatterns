

using System.Text.Json.Serialization;

namespace Infra.LegoModels;

public class Brick
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public Color Color { get; set; }
    
    // One brick can have multiple tags
    [JsonIgnore]
    public List<Tag> Tags { get; set; } = new List<Tag>();
    
    
    // Many side of brick availability 
    [JsonIgnore]
    public List<BrickAvailability> Availabilities { get; set; } = new List<BrickAvailability>();
}



public enum Color
{
    Red,
    Blue,
    Green,
    Pink,
    Yellow
}