using FluentValidation;
using IdeaBank.Models.DTOs.UserDtos;

namespace IdeaBank.Validation.UserDtosValidation;

public class CreateUserDtoValidator: AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(u => u.Name).NotEmpty().WithMessage("Name is required");
    }
    
}