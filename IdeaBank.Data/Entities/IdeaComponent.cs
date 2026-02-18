namespace IdeaBank.Data.Entities;

public class IdeaComponent
{
    public Guid IdeaId { get; set; }
    public Idea Idea { get; set; }
    
    public Guid ComponentId { get; set; }
    public Component Component { get; set; }
}