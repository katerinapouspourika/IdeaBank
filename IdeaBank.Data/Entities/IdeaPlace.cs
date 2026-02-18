namespace IdeaBank.Data.Entities;

public class IdeaPlace
{
    public Guid IdeaId { get; set; }
    public Idea Idea { get; set; }
    
    public Guid PlaceId { get; set; }
    public Place Place { get; set; }
}