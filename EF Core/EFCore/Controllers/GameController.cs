using Infra.VideoGameManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController: ControllerBase
{
    private readonly VideoGameDataContext _context;

    public GameController(VideoGameDataContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<IActionResult> GetVideoGames()
    {
        var games = await _context
            .Games.Include(game => game.Genre)
            .ToListAsync();
        return Ok(games);
    }

    [HttpGet("{id:int}", Name = "GetGame")]
    public async Task<IActionResult> GetGameById(int id)
    {
        var game = await _context.Games.FindAsync(id);
        return Ok(game);
    }

    [HttpPost]
    public async Task<IActionResult> AddVideoGame([FromBody] Game game)
    {
        var addedGameEntity = (await _context.AddAsync(game));
        await _context.SaveChangesAsync();
        var addedGame = addedGameEntity.Entity;
        return CreatedAtRoute("GetGame", new {id = addedGame.Id}, addedGame);
    }
}