using IdeaBank.Data;

namespace IdeaBank.Models.DTOs.UserRoleDtos;

public class ReturnIdeaUserDto
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public UserRole UserRole { get; set; }
}