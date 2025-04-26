using Base.Application.Interfaces;
using Base.Application.Settings;
using Base.Domain.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Base.Infrastructure.Services.Auth;

public class JwtService : IJwtService
{
	private readonly JwtSettings _jwtSettings;

	public JwtService(IOptions<JwtSettings> jwtSettings)
	{
		_jwtSettings = jwtSettings.Value;
	}

	public string GenerateToken(User user)
	{
		var jti = Guid.NewGuid().ToString();
		var expiration = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes);

		var claims = new List<Claim>
		{
			new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
			new Claim(JwtRegisteredClaimNames.Jti, jti), // TOKEN ID
			new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
			new Claim(ClaimTypes.Name, user.UserName),
			new Claim(ClaimTypes.Role, user.Role.ToString()),
			new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(expiration).ToUnixTimeSeconds().ToString()) // EXPIRE TIMESTAMP
		};

		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		var token = new JwtSecurityToken(
			issuer: _jwtSettings.Issuer,
			audience: _jwtSettings.Audience,
			claims: claims,
			expires: expiration,
			signingCredentials: creds);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}