using IdeaBank.Shared;

namespace IdeaBank.Models.DTOs.IdeaHelperDtos;

public class ReturnIdeaHelperDto
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public HelpType HelpType { get; set; }
}