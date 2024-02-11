using Microsoft.EntityFrameworkCore;

namespace Infra.VideoGameManager;

public class VideoGameDataContext: DbContext
{
    public VideoGameDataContext(DbContextOptions<VideoGameDataContext> options): base(options) { }


    public DbSet<Game> Games { get; set; }
    
    public DbSet<GameGenre> GameGenres { get; set; }
    
}