using Base.Domain.Entities;

namespace Base.Domain.Identity;

public class RefreshToken : BaseEntity
{
	public long UserId { get; set; }
	public string TokenHash { get; set; } = null!;
	public string TokenSalt { get; set; } = null!;
	public DateTimeOffset Expiration { get; set; }
	public User User { get; set; } = null!;
}