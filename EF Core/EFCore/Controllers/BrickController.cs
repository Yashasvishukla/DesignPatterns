using Infra.LegoModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrickController: ControllerBase
{
    private readonly BrickContext _context;

    public BrickController(BrickContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBricks()
    {
        /*
        
        var bricks =  await _context.Bricks.AsQueryable()
            .AsNoTracking()
            .Include(brick => brick.Tags)
            .Include(brick => brick.Availabilities).ToListAsync();
             return bricks.Any() ? Ok(bricks): NoContent();
        */

/*        var brickAvailability = await _context.BrickAvailabilities
            .AsQueryable()
            .Include(brickAvailability => brickAvailability.Brick)
            .Include(brickAvailability => brickAvailability.Vendor)
            .ToListAsync();




        var bricksWithVendorAndTagsWithIncludes = await _context
            .Bricks
            .AsQueryable()
            .Include(brick => brick.Availabilities)
            .ThenInclude(b => b.Vendor)
            .Include(brick => brick.Tags)
            .Select( brick => new
            {
                Name = brick.Title,
                Color = brick.Color,
                Id = brick.Id,
                Availibalities = brick.Availabilities,
                Tags = brick.Tags
            })
            .ToListAsync();
            
            
*/

        var bricksWithVendorAndTags = await _context
            .Bricks
            .Include($"{nameof(Brick.Availabilities)}.{nameof(BrickAvailability.Vendor)}")
            .Include(brick => brick.Tags)
            .Select( brick => new
            {
                Name = brick.Title,
                Color = brick.Color,
                Id = brick.Id,
                Avalibalities = brick.Availabilities,
                Tags = brick.Tags
            })
            .ToListAsync();
        
        
        // Explicit loading of the entities
        
        var brickWithId1 = await _context.Bricks
            .ToListAsync();
        
        
        // Explicit load the Tags and availability for the selected brick

        await _context.Entry(brickWithId1.ElementAt(0)).Collection(item => item.Tags).LoadAsync();
        
        return Ok(brickWithId1.ElementAt(0));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrickById(int id)
    {
        var bricks = await _context.Bricks.ToListAsync().ConfigureAwait(false);

        var avail = bricks.ElementAt(0).Availabilities.ElementAt(0);
        
        
        // Explicit loading the tags and availability entities

        /*
        await _context.Entry(brick).Collection(b => b.Availabilities).LoadAsync().ConfigureAwait(false);
        await _context.Entry(brick).Collection(brick => brick.Tags).LoadAsync().ConfigureAwait(false);
        */

        return Ok(bricks?.Count);
    }
}
















/*
     // Try to add the brick and save Changes
        var vendor = new Vendor
        {
            VendorName = "Yashasvi"
        };
        await _context.AddAsync(vendor);
        await _context.SaveChangesAsync();

        var tag = new Tag
        {
            Title = "Mostly Rare"
        };
        await _context.AddAsync(tag);
        await _context.SaveChangesAsync();

        
        var brick = new MinifigHead()
        {
            Title = "Brick4",
            Color = Color.Blue,
            Tags = new List<Tag>
            {
                tag
            },
            Availabilities = new List<BrickAvailability>
            {
                new()
                {
                    AvailableAmount = 80,
                    Price = 500,
                    Vendor = vendor
                    
                }
            },
            IsDualSided = true
        };
        var brickEntity = await _context.AddAsync(brick);
        await _context.SaveChangesAsync();
*/