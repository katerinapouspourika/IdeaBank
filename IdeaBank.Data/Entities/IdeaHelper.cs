namespace IdeaBank.Data.Entities;

public class IdeaHelper
{
    public Guid IdeaId { get; set; }
    public Idea Idea { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
}