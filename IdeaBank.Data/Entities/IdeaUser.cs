using IdeaBank.Shared;

namespace IdeaBank.Data.Entities;

public class IdeaUser
{
    public Guid IdeaId { get; set; }
    public Idea Idea { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public UserRole UserRole { get; set; }
}