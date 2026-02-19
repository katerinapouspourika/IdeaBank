using IdeaBank.Shared;
namespace IdeaBank.Models.DTOs.IdeaHelperDtos;


public class CreateIdeaHelperDto
{
    public Guid UserId { get; set; }
    public Guid IdeaId { get; set; }
    public HelpType HelpType { get; set; }
}