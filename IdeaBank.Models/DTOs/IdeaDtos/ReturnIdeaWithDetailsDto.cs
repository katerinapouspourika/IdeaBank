using IdeaBank.Data;
using IdeaBank.Models.DTOs.ComponentDtos;
using IdeaBank.Models.DTOs.Place;
using IdeaBank.Models.DTOs.SectorDtos;
using IdeaBank.Models.DTOs.UserDtos;

namespace IdeaBank.Models.DTOs.Idea;

public class ReturnIdeaWithDetailsDto
{
    public Guid IdeaId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateOnly Date { get; set; }
    public IdeaStatus Status { get; set; }
    
    
    public List<ReturnComponentDto> Components { get; set; }
    public List<ReturnSectorDto>  Sectors { get; set; }
    public List<ReturnPlaceDto> Places { get; set; }
    public List<ReturnUserDto> Creator { get; set; }
    public List<ReturnIdeaDto> Helpers { get; set; }
    
}