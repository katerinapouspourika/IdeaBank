using FluentValidation;
using IdeaBank.Models.DTOs.Idea;

namespace IdeaBank.Validation.IdeaDtosValidation;

public class UpdateIdeaDtoValidator :AbstractValidator<UpdateIdeaDto>
{
    public UpdateIdeaDtoValidator()
    {
        RuleFor(i => i.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(i => i.Description).NotEmpty().WithMessage("Description is required");
    }
}