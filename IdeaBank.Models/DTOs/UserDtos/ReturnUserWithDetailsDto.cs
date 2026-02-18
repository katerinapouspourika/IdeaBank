using IdeaBank.Models.DTOs.Idea;

namespace IdeaBank.Models.DTOs.UserDtos;

public class ReturnUserWithDetailsDto
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public List<ReturnIdeaDto> CreatedIdeas { get; set; }
}