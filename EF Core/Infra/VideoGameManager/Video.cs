using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace Infra.VideoGameManager;

public class GameGenre
{
    public int Id { get; set; }

    [MaxLength(150)] [Required] 
    public string Name { get; set; } = string.Empty;

    // This is the n side of the relation mapping -> one genre belongs to multiple games
    
    [JsonIgnore]   // -> Ignore the cycle from GameGenre to game
    public List<Game> Games { get; set; } = new List<Game>();
}

public class Game
{
    
    public int Id { get; set; }

    [MaxLength(150)] [Required] public string Name { get; set; } = string.Empty;

    // This is the one side of relation mapping -> one game should belongs to one genre
    public GameGenre Genre { get; set; }

    public int Rating { get; set; }
}