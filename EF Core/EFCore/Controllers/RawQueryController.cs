using Infra.Dish;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Controllers;

/*
 * In this module we will learn about executing the RawSql queries with the help of EFCore
 */
[ApiController]
[Route("api/[controller]")]
public class RawQueryController: ControllerBase
{
    private readonly CookbookContext _context;

    public RawQueryController(CookbookContext context)
    {
        _context = context;
    }
    [HttpGet("FromSqlRaw")]
    public async Task<IActionResult> FromRawSql()
    {
        var dishes = await _context.Dishes
            .FromSqlRaw("select * from Dishes as d order by d.Title desc")
            .AsNoTracking()
            .ToListAsync();
        return Ok(dishes);
    }

    [HttpGet("FromSqlInterpolated")]
    public async Task<IActionResult> FromSqlInterpolated()
    {
        var dishWithLetterN = "%N%";

        var dishes =
            await _context.Dishes.FromSqlInterpolated($"select * from dishes where title like {dishWithLetterN}")
                .AsNoTracking().ToListAsync();

        return Ok(dishes);
    }

    [HttpGet("ExecuteSqlRaw/{id}")]
    public async Task<IActionResult> ExecuteSqlRaw(int id)
    {
        var title = "yash";

        /*
         * ExecuteSqlRawAsync -> is also one of the way
         */
        var result = await _context.Database.ExecuteSqlInterpolatedAsync($"Update Dishes set Title='{title}' where Id = {id}");
        return Ok(result);

    }


    [HttpGet("SqlInjectionBadPractice")]
    public async Task<IActionResult> SqlInjectionBadPractice()
    {
        var filter = "%N%; Drop table abc;";
        var dishes = await _context.Dishes.FromSqlRaw("select * from dishes where Notes like '" + filter + "'")
            .ToListAsync();
        return Ok(dishes);
    }
    
}