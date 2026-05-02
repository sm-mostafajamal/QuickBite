namespace QuickBite.Application.Features.Authentication.Commands.Login;

using MediatR;
using QuickBite.Application.Common.interfaces.Authentication;
using QuickBite.Application.Common.Interfaces.Persistence;
using QuickBite.Application.Features.Authentication.CommonDTOs;

public record LoginCommand(string Email, string Password) : IRequest<AuthenticationResult>;

public class LoginCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) 
    : IRequestHandler<LoginCommand, AuthenticationResult>
{

    public async Task<AuthenticationResult> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var user = userRepository.GetUserByEmail(command.Email, cancellationToken);

        if(user is null)
        {
            throw new Exception("User doesn't exists");
        }

        if(user.Password != command.Password)
        {
            throw new Exception("Incorrect password");
        }

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );             
    }
}

