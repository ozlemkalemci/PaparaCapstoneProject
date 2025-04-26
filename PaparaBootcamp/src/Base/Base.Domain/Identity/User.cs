using Base.Domain.Entities;
using Base.Domain.Enums;

namespace Base.Domain.Identity;

public class User : BaseEntity
{
	public string UserName { get; set; }
	public string PasswordHash { get; set; }
	public string Email { get; set; } = null!;
	public string Secret { get; set; }
	public UserRole Role { get; set; }
	public DateTimeOffset OpenDate { get; set; }
	public DateTimeOffset? LastLoginDate { get; set; }
}