using QuickBite.Application.Common.interfaces.Authentication;

namespace QuickBite.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        var userId = Guid.NewGuid();

        return new AuthenticationResult(
            userId, 
            firstName, 
            lastName, 
            email, 
            _jwtTokenGenerator.GenerateToken(userId, firstName, lastName)
        );
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(), 
            "firstName", 
            "lastName", 
            email, 
            "token"
        ); 
    }

}

