using Microsoft.EntityFrameworkCore;

namespace Infra.Dish;

public class CookbookContext: DbContext
{
    public CookbookContext(DbContextOptions<CookbookContext> options) : base(options)
    {
    }


    public DbSet<Dish> Dishes { get; set; }
    public DbSet<DishIngredient> Ingredients  { get; set; }
}