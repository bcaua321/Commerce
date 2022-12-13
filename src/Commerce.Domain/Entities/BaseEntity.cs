
public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreateDate { get; private set; } = Datetime.UtcNow; 
}