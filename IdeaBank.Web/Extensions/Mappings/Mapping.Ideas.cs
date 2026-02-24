using IdeaBank.Data.Entities;
using IdeaBank.Models.DTOs.Idea;

namespace IdeaBank.Web.Extensions.Mappings;

public static class MappingIdeas
{
    public static Idea ToIdea(this CreateIdeaDto dto)
    {
        return new Idea
        {
            IdeaId = Guid.NewGuid(),
            Title = dto.Title,
            Description = dto.Description,
            UserId = dto.UserId,
        };
    }

    public static void UpdateIdea(this Idea idea, UpdateIdeaDto dto)
    {
        idea.Title = dto.Title;
        idea.Description = dto.Description;
    }

    public static ReturnIdeaDto ToReturnIdeaDto(this Idea idea)
    {
        return new ReturnIdeaDto
        {
            IdeaId = idea.IdeaId,
            Title = idea.Title,
            Description = idea.Description
        };
    }

    public static ReturnIdeaWithDetailsDto ToReturnUserDto(this Idea idea)
    {
        return new ReturnIdeaWithDetailsDto
        {
            IdeaId = idea.IdeaId,
            Title = idea.Title,
            Description = idea.Description
            
        };
    }
}