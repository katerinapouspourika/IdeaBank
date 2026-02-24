using IdeaBank.Data;
using IdeaBank.Data.Entities;
using IdeaBank.Models.DTOs.ErrorMessageDto;
using IdeaBank.Models.DTOs.Idea;
using IdeaBank.Web.Extensions.Mappings;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace IdeaBank.Web.Endpoints.IdeaEndpoints;

using Microsoft.AspNetCore.Routing; 
using Microsoft.AspNetCore.Builder;

public class IdeaEndpoints
{
    public static RouteGroupBuilder Map(RouteGroupBuilder endpoint)
    {
        var group = endpoint.MapGroup("idea").WithTags("Idea");

        group.MapPost(string.Empty, CreateIdea);
        group.MapGet("{id:guid}", GetIdeaById)
            .WithName(nameof(GetIdeaById));

        return endpoint;
    }

    public static async Task<Results<CreatedAtRoute<ReturnIdeaDto>, NotFound<ErrorMessage>, Conflict<ErrorMessage>>>
        CreateIdea
        (CreateIdeaDto createIdeaDto,
            IdeaBankDbContext db,
            ILogger<IdeaEndpoints> logger,
            CancellationToken cancellationToken = default)
    {
        logger.LogInformation(nameof(Idea));

        var idea = createIdeaDto.ToIdea();
        
        db.Ideas.Add(idea);

        try
        {
            await db.SaveChangesAsync(cancellationToken);
        }
        catch
        {
            logger.LogError(nameof(Idea));
            return TypedResults.Conflict(new ErrorMessage("Idea not created"));
        }

        var returnIdeadto = idea.ToReturnIdeaDto();
        
        return TypedResults.CreatedAtRoute(returnIdeadto, nameof(GetIdeaById), new {id=returnIdeadto.IdeaId});
    }

    public static async Task<Results<Ok<ReturnIdeaDto>, NotFound<ErrorMessage>>> GetIdeaById(
        Guid id,
        IdeaBankDbContext db,
        ILogger<IdeaEndpoints> logger,
        CancellationToken cancellationToken = default)
    {
        var idea = await db.Ideas
            .AsNoTracking()
            .Where(i => i.IdeaId == id)
            .Select(i => i.ToReturnIdeaDto())
            .FirstOrDefaultAsync(cancellationToken);

        if (idea == null)
        {
            logger.LogError(nameof(GetIdeaById));
            return TypedResults.NotFound(new ErrorMessage("Idea not found"));
        }
        
        return TypedResults.Ok(idea);
    }


}