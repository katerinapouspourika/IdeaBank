using IdeaBank.Data;

namespace IdeaBank.Models.DTOs.UserRoleDtos;

public class CreateIdeaUserDto
{
    public Guid IdeaId { get; set; }
    public Guid UserId { get; set; }
    public UserRole UserRole { get; set; }
}