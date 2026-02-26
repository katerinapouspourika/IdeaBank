using FluentValidation;
using IdeaBank.Models.DTOs.Idea;

namespace IdeaBank.Validation.IdeaDtosValidation;

public class CreateIdeaDtoValidator : AbstractValidator<CreateIdeaDto>
{
    public CreateIdeaDtoValidator()
    {
        RuleFor(i => i.Title).NotNull().NotEmpty().WithMessage("Title is required");
        RuleFor(i => i.UserId).NotEmpty();
    }
}