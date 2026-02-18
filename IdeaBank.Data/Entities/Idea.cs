namespace IdeaBank.Data.Entities;

public class Idea
{
    public Guid IdeaId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateOnly Date { get; set; }
    public IdeaStatus Status { get; set; }
    
    
    public ICollection<IdeaSector> IdeaSectors { get; set; }
    public ICollection<IdeaComponent> IdeaComponents { get; set; }
    public ICollection<IdeaPlace> IdeaPlaces { get; set; }
    public ICollection<IdeaUser> IdeaUsers { get; set; }
    public ICollection<IdeaHelper>  IdeaHelpers { get; set; }
    
    public Guid UserId { get; set; }
    public User Creator { get; set; }
}