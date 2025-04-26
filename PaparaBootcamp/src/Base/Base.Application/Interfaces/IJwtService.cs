using Base.Domain.Identity;

namespace Base.Application.Interfaces;

public interface IJwtService
{
	Task<string> GenerateToken(User user);
}