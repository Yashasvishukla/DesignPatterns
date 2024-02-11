using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Dish;

public class Dish
{
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Notes { get; set; }

    public int? Stars { get; set; }
    
    // many relation ship
    public List<DishIngredient> Ingredients { get; set; } = new();
}



public class DishIngredient
{
    public int Id { get; set; }
    
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(50)]
    public string UnitOfMeasure { get; set; } = string.Empty;
    
    public decimal Amount { get; set; }
    
    
    // One side of the relation ship
    public int? DishId { get; set; }
    public Dish? Dish { get; set; }

}