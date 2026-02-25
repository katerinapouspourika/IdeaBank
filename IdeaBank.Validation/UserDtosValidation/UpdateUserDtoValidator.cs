using FluentValidation;
using IdeaBank.Models.DTOs.UserDtos;

namespace IdeaBank.Validation.UserDtosValidation;

public class UpdateUserDtoValidator: AbstractValidator<UpdateUserDto>
{
    public UpdateUserDtoValidator()
    {
        RuleFor(u => u.Name).NotEmpty().WithMessage("Name is required");
    }
}