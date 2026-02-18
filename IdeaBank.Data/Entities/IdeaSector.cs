namespace IdeaBank.Data.Entities;

public class IdeaSector
{
    public Guid IdeaId { get; set; }
    public Idea Idea { get; set; }
    
    public Guid SectorId { get; set; }
    public Sector Sector { get; set; }
}