using IdeaBank.Data.Entities;
using IdeaBank.Models.DTOs.UserDtos;

namespace IdeaBank.Web.Extensions.Mappings;

public static class MappingUser
{
   public static User ToUser(this User dto)
   {
      return new User
      {
         UserId = dto.UserId,
         Name = dto.Name,
         Surname = dto.Surname,
      };
   }

   public static void UdpateUser(this User dto, User user)
   {
      user.Name = dto.Name;
      user.Surname = dto.Surname;
   }

   public static ReturnUserDto ToReturnUser(this User user)
   {
      return new ReturnUserDto
      {
         UserId = user.UserId,
         Name = user.Name,
         Surname = user.Surname
      };
   }
}