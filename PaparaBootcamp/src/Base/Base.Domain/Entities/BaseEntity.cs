namespace Base.Domain.Entities;

public class BaseEntity
{
	public long Id { get; set; }
	public long CreatedById { get; set; }
	public DateTimeOffset CreatedDate { get; set; }
	public long? UpdatedById { get; set; }
	public DateTimeOffset? UpdatedDate { get; set; }
	public long? DeletedById { get; set; }
	public DateTimeOffset? DeletedDate { get; set; }
	public bool IsActive { get; set; }
}