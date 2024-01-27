using Infra.Dish;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DishController:ControllerBase
{
    private readonly CookbookContext _context;
    private readonly IConfiguration _configuration;

    // CookbookContext is registered as the Scoped Services in the DI container
    public DishController(CookbookContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    [HttpGet("efCoreStates")]
    public async Task<IActionResult> AddDishes()
    {
        
        /*
         * States
         *
         * Detached
         * Unchanged
         * Added
         * Modified
         * DeletedState
         */
        
        // Lets go through different states of Entity Framework core on an entity
        
        
        var dish = new Dish()
        {
            Title = "Foo",
            Notes = "Bar"
        };

        var state = _context.Entry(dish).State;
        Console.WriteLine($"Initial State of the dish ------------> {state}");    // Detached State

        await _context.AddAsync(dish);
        state = _context.Entry(dish).State;
        Console.WriteLine($"Entity marked for the change tracking -------> {state}");  // Added State

        await _context.SaveChangesAsync();
        state = _context.Entry(dish).State;
        Console.WriteLine($"Entity Added to the database -----------> {state}");     // Unchanged State
        
        dish.Notes = "New Notes added";
        state = _context.Entry(dish).State;
        Console.WriteLine($"Entity has been modified --------> {state}");           // Modified State
        
        await _context.SaveChangesAsync();
        state = _context.Entry(dish).State;
        Console.WriteLine($"Entity Updated to the database -----------> {state}");   


        _context.Dishes.Remove(dish);
        state = _context.Entry(dish).State;
        Console.WriteLine($"Entity has been marked for the removed from the database ----------> {state}"); // Deleted State

        await _context.SaveChangesAsync();
        state = _context.Entry(dish).State;
        Console.WriteLine($"State of the database has been update --------> {state}"); // Detached State
        
        return Ok(dish);

    }

    [HttpGet("efCoreTracking")]
    public async Task<IActionResult> GetDishTracking()
    {
        /*
         * ------------------------------------------------ Change tracker works specific to the database context -----------------------------------------
         */
        
        
        // Working with First DBContext
        var newDish = new Dish()
        {
            Title = "New Title",
            Notes = "New Dish Notes"
        };

        // Add the entity to change tracking system
        await _context.AddAsync(newDish);                                                                             // State :-> Added
        await _context.SaveChangesAsync(); 

        
        /*
         * The value is just in memory we didn't save it to database
         */
        newDish.Notes = "Lets modify the notes of the dish";                                                         // State:-> Modified
  
        var entry = _context.Entry(newDish);
        var originalValue = entry.OriginalValues[nameof(Dish.Notes)]?.ToString();                                    // OriginalValue :-> New Dish Notes
        var currentValue = entry.CurrentValues[nameof(Dish.Notes)]?.ToString();
        /*
         * Change tracker compares the value of the original and the current
         * if there is any modification then it will update the entityState from Unchanged to Modified
         */
        
        
        var dishFromDatabase = await _context.Dishes.FirstOrDefaultAsync(dish => dish.Id == newDish.Id);             // Notes:-> Lets modify the notes of the dish  (Value coming from change tracker)
        
        /*
         * If the entity is been tracked then the EFCore will not go the database and re fetch the entity
         * It will return the entity from the Change tracker only.
         * This will return the unwritten changes even though they are not written in the databases
         */
        Console.WriteLine(dishFromDatabase?.Notes);       // Updated value of Dish


        
        // Creating a new DBContext and validating the outcomes
        var optionBuilder = new DbContextOptionsBuilder<CookbookContext>();
        optionBuilder.UseSqlite(_configuration.GetConnectionString("CookbookConnection"));
        var newContext = new CookbookContext(optionBuilder.Options);
        
        // This does no idea about the newDish that is being tracked by other dbContext
        var dishFromAnotherContext = await newContext.Dishes.FirstOrDefaultAsync(d => d.Id == newDish.Id);
        Console.WriteLine(dishFromAnotherContext?.Notes);


        return Ok();
    }

    [HttpGet("update")]
    public async Task<IActionResult> UpdateMethodInEf()
    {
        var newDish = new Dish()
        {
            Title = "Dish Title",
            Notes = "Dish Notes"
        };
        
        // State would be detached

        var addedEntity = await _context.AddAsync(newDish);
        await _context.SaveChangesAsync();

        addedEntity.Entity.Notes = "Modified Notes";

        var state = _context.Entry(addedEntity.Entity).State;
        
        
        /*
         * Begin the entity tracking in the modified state by default
         * Case 1: When the primary is already present -> Operates in the Modified state
         * Case 2: When the primary is not present -> Operates in the Added State
         */
        
        _context.Dishes.Update(addedEntity.Entity);
        
        /*
         *
         * There is a difference between the direct update on the values and doing with the update()
         */
        
        
        
        /*
         * We can set the state of the entity as well
         */

        state = EntityState.Detached;



        var dishFromDb = new Dish()
        {
            Id = 10,
            Title = "New Updated Title",
            Notes = "New Updated Notes"
        };
        _context.Dishes.Update(dishFromDb);
        
        await _context.SaveChangesAsync();

        return Ok();
    }


    [HttpGet("AsNoTracking")]
    public async Task<IActionResult> ASNoTrackingEFCore()
    {
        /*
         * This would not add the entities to the change tracking
         *
         * Performance Improvement ->
         * If we don't add the AsNoTracking what really happens under the hood is
         * it will compare all the entities with the originalValues with the currentValues
         *
         * It will set the entities state accordingly -> those who have modified will be marked as the Modified state and those who have removed will be marked as Detached and like wise
         */
        
        
        /*
         * Add AsNoTracking will no allow all this compare to happen
         * Would only be suitable in case of ReadOnly.
         * We don't want to write anything back to database
         */
        var dishes = await _context.Dishes.AsNoTracking().ToListAsync();
        return Ok(dishes);
    }
    
    
}