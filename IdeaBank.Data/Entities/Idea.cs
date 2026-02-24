using IdeaBank.Data;
using IdeaBank.Data.Entities;
using IdeaBank.Shared;

namespace IdeaBank.Data.Entities;

public class Idea
{
    public Guid IdeaId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    
    public Guid UserId { get; set; }
}