using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models;
using P7CreateRestApi.Services.Interfaces;

[Authorize(Roles = Roles.Admin)]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    /// <summary>
    /// Obtenir la liste de tout les utilisateurs
    /// </summary>
    /// <returns></returns>
    [Authorize(Roles = Roles.Admin)]
    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAllUsers()
    {
        List<ApplicationUser> users = _userManager.Users.ToList();

        if (users.Count <= 0) return NotFound("Il n'y a pas d'utilisateurs inscrits actuellement");

        return Ok(users);
    }

    /// <summary>
    /// Obtenir un utilisateur � partir de son ID
    /// </summary>
    /// <param name="id">Id de l'utilisateur</param>
    /// <returns>Applicationuser</returns>
    /// <exception cref="ArgumentException"></exception>
    [Authorize(Roles = Roles.Admin)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(string userId)
    {
        ApplicationUser user = await _userManager.FindByIdAsync(userId);

        if (user is null) return NotFound("Utilisateur introuvable");
        return Ok(user);
    }

    /// <summary>
    /// Cr�er un utilisateur
    /// </summary>
    /// <param name="user">ApplicationUser</param>
    /// <returns>Ok</returns>
    [Authorize(Roles = "Admin, Manager")]
    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] RegisterModel model)
    {
        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);
        var roles = await _userManager.AddToRoleAsync(user, "User");

        return Ok("Utilisateur cr�� avec succ�s !");
    }

    /// <summary>
    /// Mettre � jour un utilisateur
    /// </summary>
    /// <param name="id">Id de l'utilisateur</param>
    /// <param name="user">ApplicationUser</param>
    /// <returns>Utilisateur mis � jour</returns>
    [Authorize(Roles = "Admin, Manager")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] ApplicationUser user)
    {
        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
            return NotFound(result.Errors);

        return Ok($"Utilisateur {user} mis � jour avec succ�s");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound("Utilisateur introuvable.");
        }

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok($"Utilisateur {user.UserName} supprim�.");
    }

}
