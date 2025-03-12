using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using P7CreateRestApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthController> _logger;

    public AuthController(UserManager<ApplicationUser> userManager,
                          RoleManager<IdentityRole> roleManager,
                          IConfiguration configuration,
                          ILogger<AuthController> logger)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _logger = logger;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);
        var roles = await _userManager.AddToRoleAsync(user, "User");

        return Ok("Utilisateur créé avec succès !");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var user = await _userManager.FindByNameAsync(model.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            return Unauthorized("Identifiants incorrects");

        var roles = await _userManager.GetRolesAsync(user);

        // Création du token JWT
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // Ajout des rôles au token
        foreach (var role in roles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
        var token = new JwtSecurityToken(
            expires: DateTime.UtcNow.AddHours(2),
            claims: authClaims,
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );
        _logger.LogInformation($"Utilisateur {user.Id} connecté. Token généré et envoyé.");

        return Ok(new
        {
            message = "Utilisateur connecté, token de connexion généré.",
            token = new JwtSecurityTokenHandler().WriteToken(token)
        });
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpPost("assign-role")]
    public async Task<IActionResult> AssignRole([FromBody] AssignRoleModel model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user == null) return NotFound("Utilisateur introuvable");

        _logger.LogInformation($"Tentative d'attribution du rôle '{model.Role}' à l'utilisateur '{model.Username}'.");

        if (!await _roleManager.RoleExistsAsync(model.Role))
        {
            _logger.LogInformation($"Le rôle '{model.Role}' n'existe pas, création en cours.");
            await _roleManager.CreateAsync(new IdentityRole(model.Role));
        }

        await _userManager.AddToRoleAsync(user, model.Role);
        _logger.LogInformation($"Rôle '{model.Role}' assigné avec succès à {model.Username}.");

        return Ok($"Rôle '{model.Role}' assigné à {model.Username}");
    }


    [Authorize]
    [HttpGet("get-roles/{username}")]
    public async Task<IActionResult> GetRoles(string username)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user == null) return NotFound("Utilisateur introuvable");

        var roles = await _userManager.GetRolesAsync(user);
        return Ok(roles);
    }

}
