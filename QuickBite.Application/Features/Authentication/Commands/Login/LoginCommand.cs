namespace QuickBite.Application.Features.Authentication.Commands.Login;

using ErrorOr;
using MediatR;
using QuickBite.Application.Common.interfaces.Authentication;
using QuickBite.Application.Common.Interfaces.Persistence;
using QuickBite.Application.Common.Interfaces.Persistence.Repositories;
using QuickBite.Application.Features.Authentication.CommonDTOs;
using QuickBite.Domain.Common.Errors;

public record LoginCommand(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;

public class LoginCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) 
    : IRequestHandler<LoginCommand, ErrorOr<AuthenticationResult>>
{

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var user = userRepository.GetUserByEmail(command.Email, cancellationToken);

        if(user is null)
        {
            return Errors.User.NotExist;
        }

        if(user.Password != command.Password)
        {
            return Errors.Authentication.WrongCredential;
        }

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );             
    }
}

