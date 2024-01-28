using System.Linq.Expressions;
using Infra.Dish;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpressionTreeController : ControllerBase
{
    private readonly CookbookContext _context;

    public ExpressionTreeController(CookbookContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> ExpressionTree()
    {
        var dishes = await _context.Dishes.Where(dish => dish.Title.StartsWith("N")).ToListAsync();
        
        
        // This is complied and converted into machine code and EFCore translate the compile code into actual Sql query
        /*
         * There is a catch -> How does EFCore is able to understand the compile code
         * The ans is it Make use of Expression that actually creates the Expression tree. This is not kind of complied into machine code
         *
         * Lets have a look
         */

        Expression<Func<Dish, bool>> expressionTitleStartsWithN = dish => dish.Title.StartsWith("N");

        Func<Dish, bool> func = dish => dish.Title.StartsWith("N");


        return Ok(dishes);
    }
}