using Microsoft.EntityFrameworkCore;

namespace Infra.LegoModels;

public class BrickContext: DbContext
{
    public BrickContext(DbContextOptions<BrickContext> options): base(options)
    {
        
    }


    public DbSet<Brick> Bricks { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<BrickAvailability> BrickAvailabilities { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*
         * I have to explicitly tell the EF core about the inheritance
         * we have between the Brick and BasePlate and the minifigHead
         */
        modelBuilder.Entity<BasePlate>().HasBaseType<Brick>();
        modelBuilder.Entity<MinifigHead>().HasBaseType<Brick>();
    }
}