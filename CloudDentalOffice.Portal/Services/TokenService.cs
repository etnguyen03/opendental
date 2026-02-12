using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CloudDentalOffice.Portal.Services;

public interface ITokenService
{
    string GenerateToken(string userId, string email, string tenantId);
}

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(string userId, string email, string tenantId)
    {
        var key = _configuration["Jwt:Key"] ?? "ThisIsASecretKeyForDevelopmentOnly_DoNotUseInProduction_MakeItLonger";
        var issuer = _configuration["Jwt:Issuer"] ?? "CloudDentalOffice";
        var audience = _configuration["Jwt:Audience"] ?? "CloudDentalOffice";

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim("tenant_id", tenantId),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
