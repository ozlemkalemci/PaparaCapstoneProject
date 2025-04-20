using Base.Domain.Identity;

namespace Base.Application.Interfaces;

public interface IJwtService
{
	string GenerateToken(User user);
}