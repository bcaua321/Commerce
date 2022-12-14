namespace Commerce.Domain.Entities;
public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreateTime { get; set; } = DateTime.UtcNow;
}