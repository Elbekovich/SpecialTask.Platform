namespace SpecialTask.Domain.Entities.Posts;

public class Post : Auditable
{
    public long CategoryId { get; set; }
    public  long UserId { get; set; }
    public string PostImage { get; set; } = String.Empty;
    public string Title { get; set; } = String.Empty;
    public double Price { get; set; } 
    public string Description { get; set; } = String.Empty;
    public string Region { get; set; } = String.Empty;

    public string PhoneNumber { get; set; } = String.Empty;


}
