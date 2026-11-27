using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly TokenService _tokenService;

    public AuthController(UserManager<ApplicationUser> userManager, TokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    [HttpPost("registro")]
    public async Task<IActionResult> Registro(RegistroDto dto)
    {
        var usuario = new ApplicationUser
        {
            UserName = dto.Email,
            Email = dto.Email,
            NomeCompleto = dto.Nome,

        };
        var resultado = await _userManager.CreateAsync(usuario, dto.Senha);
        if (!resultado.Succeeded)
        {
        return BadRequest(resultado.Errors.Select(e => e.Description));
        }
        return StatusCode(201);

    }

        [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
                var usuario = await _userManager.FindByEmailAsync(dto.Email);
        if (usuario == null || !await _userManager.CheckPasswordAsync(usuario, dto.Senha))
    {
        return Unauthorized("Credenciais inválidas.");  
    }
    var papeis = await _userManager.GetRolesAsync(usuario);
    return Ok(new { token = _tokenService.GerarToken(usuario, papeis)});
}
}