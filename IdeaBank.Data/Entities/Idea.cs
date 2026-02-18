namespace IdeaBank.Data.Entities;

public class Idea
{
    public Guid IdeaId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateOnly Date { get; set; }
    
    
}