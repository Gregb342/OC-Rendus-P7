using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Services.Interfaces;
using P7CreateRestApi.Models;

[Authorize(Roles = Roles.Admin)]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(string id)
    {
        if (!int.TryParse(id, out int userId))
        {
            throw new ArgumentException($"L'ID utilisateur '{id}' n'est pas un entier valide.");
        }

        var user = await _userService.GetUserByIdAsync(userId);
        if (user == null) return NotFound("Utilisateur introuvable");
        return Ok(user);
    }

    [Authorize(Roles = "Admin, Manager")]
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] ApplicationUser user)
    {
        await _userService.CreateUserAsync(user);
        return Ok("Utilisateur créé avec succès");
    }

    [Authorize(Roles = "Admin, Manager")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] ApplicationUser user)
    {
        var updatedUser = await _userService.UpdateUserAsync(user);
        if (updatedUser == null) return NotFound("Utilisateur introuvable");
        return Ok(updatedUser);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(ApplicationUser user)
    {
        if (!int.TryParse(user.Id, out int userId))
        {
            throw new ArgumentException($"L'ID utilisateur '{user.Id}' n'est pas un entier valide.");
        }

        await _userService.DeleteUserAsync(userId);
        
        return Ok();
    }
}
