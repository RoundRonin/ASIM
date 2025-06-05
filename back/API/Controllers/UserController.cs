using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("user")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet("login")]
    public async Task<IActionResult> Login([FromQuery] string username, [FromQuery] string password)
    {
        try
        {
            var token = await userService.LoginAsync(username, password);
            Response.Headers["X-Rate-Limit"] = "1000";
            Response.Headers["X-Expires-After"] = DateTime.UtcNow.AddHours(1).ToString("o");

            return Ok(token);
        }
        catch
        {
            return BadRequest("Invalid username/password");
        }
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        return Ok("Logged out");
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> GetUserByName(string username)
    {
        try
        {
            var user = await userService.GetUserByUsernameAsync(username);
            return Ok(user);
        }
        catch
        {
            return NotFound("User not found");
        }
    }

    [HttpPost("{username}/blacklist")]
    public async Task<IActionResult> AddToBlacklist(string username)
    {
        var id = await userService.AddToBlacklistAsync(username);
        return Ok(new { blacklistId = id });
    }

    [HttpDelete("{username}/blacklist")]
    public async Task<IActionResult> RemoveFromBlacklist(string username)
    {
        await userService.RemoveFromBlacklistAsync(username);
        return NoContent();
    }
}
