using ErrorOr;
using MediatR;
using QuickBite.Application.Common.interfaces.Authentication;
using QuickBite.Application.Common.Interfaces.Persistence;
using QuickBite.Application.Features.Authentication.CommonDTOs;
using QuickBite.Domain.Common.Errors;
using QuickBite.Domain.Entities;

namespace QuickBite.Application.Features.Authentication.Commands.Register;

public record RegisterCommand(string FirstName, string LastName, string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;


public class RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) 
: IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var user = userRepository.GetUserByEmail(command.Email, cancellationToken);
        
        if(user is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        userRepository.AddUser(user);
        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user, 
            token
        );
    }
}