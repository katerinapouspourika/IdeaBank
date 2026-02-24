using IdeaBank.Data;
using IdeaBank.Data.Entities;
using IdeaBank.Models.DTOs.ErrorMessageDto;
using IdeaBank.Models.DTOs.UserDtos;
using IdeaBank.Web.Extensions.Mappings;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace IdeaBank.Web.Endpoints.UserEndpoints;

public class UserEndpoints
{
    public static RouteGroupBuilder Map(RouteGroupBuilder endpoint)
    {
        var group = endpoint.MapGroup("user").WithTags("user");

        group.MapPost(string.Empty, CreateUser);
        group.MapGet("{id:guid}", GetUserById).WithName(nameof(GetUserById));
        group.MapPut("{id:guid}", UpdateUser);
        group.MapDelete("{id:guid}", DeleteUser);
        
        return endpoint;
    }

    public static async Task<Results<CreatedAtRoute<ReturnUserDto>, NotFound<ErrorMessage>, Conflict<ErrorMessage>>>
        CreateUser(
            CreateUserDto createUserDto,
            IdeaBankDbContext db,
            ILogger<UserEndpoints> logger,
            CancellationToken cancellationToken = default)
    {
        logger.LogInformation(nameof(User));

        var user = createUserDto.ToUser();
        
        db.Users.Add(user);

        try
        {
            await db.SaveChangesAsync(cancellationToken);
        }
        catch
        {
            logger.LogError(nameof(User));
            return TypedResults.Conflict(new ErrorMessage("User not created"));
        }

        var returnUserDto = user.ToReturnUser();
        return TypedResults.CreatedAtRoute(returnUserDto, nameof(GetUserById), new{id=returnUserDto.UserId});
    }

    public static async Task<Results<Ok<ReturnUserDto>, NotFound<ErrorMessage>>> GetUserById(
        Guid id,
        IdeaBankDbContext db,
        ILogger<UserEndpoints> logger,
        CancellationToken cancellationToken = default)
    {
        var user = await db.Users
            .AsNoTracking()
            .Where(u => u.UserId == id)
            .Select(u => u.ToReturnUser())
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null)
        {
            logger.LogError(nameof(User));
            return TypedResults.NotFound(new ErrorMessage("User not found"));
        }
        
        return TypedResults.Ok(user);
    }

    public static async Task<Results<Ok<ReturnUserDto>, NotFound<ErrorMessage>>> UpdateUser(
        Guid id,
        UpdateUserDto updateUserDto,
        IdeaBankDbContext db,
        ILogger<IdeaBankDbContext> logger,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation(nameof(User));

        var user = await db.Users
            .FirstOrDefaultAsync(user => user.UserId == id, cancellationToken);

        if (user == null)
        {
            logger.LogError(nameof(User));
            return TypedResults.NotFound(new ErrorMessage("The user you are looking for was not found"));
        }

        MappingUser.UpdateUser(user, updateUserDto);

        await db.SaveChangesAsync(cancellationToken);
        return TypedResults.Ok(user.ToReturnUser());
    }

    public static async Task<Results<NoContent, BadRequest>> DeleteUser(
        Guid id,
        IdeaBankDbContext db,
        ILogger<IdeaBankDbContext> logger,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation(nameof(User));

        var userToDelete = await db.Users
            .FirstOrDefaultAsync(user => user.UserId == id, cancellationToken);

        if (userToDelete == null)
        {
            logger.LogError(nameof(User));
            return TypedResults.BadRequest();
        }

        db.Users.Remove(userToDelete);

        await db.SaveChangesAsync(cancellationToken);
        
        logger.LogInformation(nameof(userToDelete));
        return TypedResults.NoContent();
    }
}