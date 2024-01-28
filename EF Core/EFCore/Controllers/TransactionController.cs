using Infra.Dish;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController: ControllerBase
{
    private readonly CookbookContext _context;

    public TransactionController(CookbookContext context)
    {
        _context = context;
    }
    
    /*
     * With Transaction we can achieve the atomic operations -> all or nothing
     */

    [HttpGet("transaction")]
    public async Task<IActionResult> Transaction()
    {
        // Lets begin the transaction
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            // First part of the transaction
            var newDish = new Dish()
            {
                Notes = "Notes of the dish",
                Title = "Title of the dish"
            };
            await _context.Dishes.AddAsync(newDish);
            await _context.SaveChangesAsync();


            // Second Part of the transaction

            await _context.Database.ExecuteSqlRawAsync("insert into Data values (1,2,3,45)");
            
            
            // if everything works fine then we can commit the transactions
            await _context.Database.CommitTransactionAsync();
        }
        catch (SqliteException e)
        {
            Console.WriteLine($"Exception has occured {e.Message}");
        }

        return Ok();
    }
    
}