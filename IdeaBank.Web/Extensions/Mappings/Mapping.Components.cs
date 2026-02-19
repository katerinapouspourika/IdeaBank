using IdeaBank.Data.Entities;
using IdeaBank.Models.DTOs.ComponentDtos;

namespace IdeaBank.Web.Extensions.Mappings;

public static class MappingComponent
{
    public static Component ToComponent(this CreateComponentDto dto)
    {
        return new Component
        {
            ComponentId = Guid.NewGuid(),
            Name = dto.Name,
        };
    }

    public static void UpdateComponent(this UpdateComponentDto dto, Component component)
    {
        component.Name = dto.Name;
    }

    public static ReturnComponentDto ToReturnComponentDto(this Component component)
    {
        return new ReturnComponentDto
        {
            ComponentId = component.ComponentId,
            Name = component.Name
        };
    }
}