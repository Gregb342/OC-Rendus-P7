using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models;
using P7CreateRestApi.Services.Interfaces;

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

    /// <summary>
    /// Obtenir la liste de tout les utilisateurs
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        List<ApplicationUser> users = (List<ApplicationUser>) await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    /// <summary>
    /// Obtenir un utilisateur à partir de son ID
    /// </summary>
    /// <param name="id">Id de l'utilisateur</param>
    /// <returns>Applicationuser</returns>
    /// <exception cref="ArgumentException"></exception>
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(string id)
    {
        if (!int.TryParse(id, out int userId))
        {
            throw new ArgumentException($"L'ID utilisateur '{id}' n'est pas un entier valide.");
        }

        ApplicationUser user = await _userService.GetUserByIdAsync(userId);
        if (user is null) return NotFound("Utilisateur introuvable");
        return Ok(user);
    }

    /// <summary>
    /// Créer un utilisateur
    /// </summary>
    /// <param name="user">ApplicationUser</param>
    /// <returns>Ok</returns>
    [Authorize(Roles = "Admin, Manager")]
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] ApplicationUser user)
    {
        await _userService.CreateUserAsync(user);
        return Ok("Utilisateur créé avec succès");
    }

    /// <summary>
    /// Mettre à jour un utilisateur
    /// </summary>
    /// <param name="id">Id de l'utilisateur</param>
    /// <param name="user">ApplicationUser</param>
    /// <returns>Utilisateur mis à jour</returns>
    [Authorize(Roles = "Admin, Manager")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] ApplicationUser user)
    {
        var updatedUser = await _userService.UpdateUserAsync(user);
        if (updatedUser == null) return NotFound("Utilisateur introuvable");
        return Ok(updatedUser);
    }

    /// <summary>
    /// Supprimer un utilisateur
    /// </summary>
    /// <param name="user">Application User</param>
    /// <returns>Ok</returns>
    /// <exception cref="ArgumentException"></exception>
    [Authorize(Roles = "Admin, Manager")]
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
