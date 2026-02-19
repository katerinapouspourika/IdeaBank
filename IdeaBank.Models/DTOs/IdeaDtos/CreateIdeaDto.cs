
namespace IdeaBank.Models.DTOs.Idea;

public class CreateIdeaDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
}