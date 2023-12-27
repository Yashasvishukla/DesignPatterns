using Microsoft.AspNetCore.Mvc;
using url_shorterner.Controllers.DTOs;
using url_shorterner.Model;
using url_shorterner.Model.RepoInterfaces;

namespace url_shorterner.Controllers;

[ApiController]
[Route("[controller]/api")]
public class UserController: ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> GetUser(string email)
    {
        var user = await _userRepository.Get(email);
        return user is null ? NotFound("User Not found") : Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] UserRecord user)
    {
        try
        {
            var newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                CreationTime = DateTime.Now,
                LastLogin = DateTime.Now
            };
            await _userRepository.Add(newUser);

            return NoContent();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Something went wrong. Please try after sometime");
        }
    }
}