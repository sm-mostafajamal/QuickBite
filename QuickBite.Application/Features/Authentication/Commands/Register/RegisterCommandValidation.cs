using FluentValidation;

namespace QuickBite.Application.Features.Authentication.Commands.Register;

public class RegisterCommandValidation : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidation()
    {
        RuleFor(x => x.Email).NotEmpty();    
        RuleFor(x => x.FirstName).NotEmpty();    
        RuleFor(x => x.LastName).NotEmpty();    
        RuleFor(x => x.Password).NotEmpty();    
    }
}