using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class TokenService
{
    private readonly IConfiguration _configuration;
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GerarToken(ApplicationUser usuario, IList<string> papeis)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id),
            new Claim(ClaimTypes.Name, usuario.NomeCompleto ??""),
            new Claim(ClaimTypes.Email, usuario.Email ??""),

        };
        foreach (var papel in papeis)
        {
            claims.Add(new Claim(ClaimTypes.Role, papel));
        }
        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:ChaveSecreta"]??""));
        var credencias = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Emissor"],
            audience: _configuration["Jwt:Publico"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiracaoEmMinutos"])),
            signingCredentials: credencias
        );

        var handler = new JwtSecurityTokenHandler();
        return handler.WriteToken(token);
    }
}