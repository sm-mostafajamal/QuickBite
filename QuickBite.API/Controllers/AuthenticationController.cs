namespace QuickBite.API.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickBite.Application.Features.Authentication.Commands.Login;
using QuickBite.Application.Features.Authentication.Commands.Register;
using QuickBite.Application.Features.Authentication.CommonDTOs;
using QuickBite.Contracts.Authentication;
using LoginRequest = QuickBite.Contracts.Authentication.LoginRequest;
using RegisterRequest = QuickBite.Contracts.Authentication.RegisterRequest;

[Route("api/auth/")]
public class AuthenticationController(ISender sender) : ApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var authResult = await sender.Send(new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password));

        return authResult.Match(
            authResult => Ok(GetAuthenticationResponse(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var authResult = await sender.Send(new LoginCommand(request.Email, request.Password));

        return authResult.Match(
            authResult => Ok(GetAuthenticationResponse(authResult)),
            errors => Problem(errors)
        );
    }

    public static AuthenticationResponse GetAuthenticationResponse(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.user.Id, 
            authResult.user.FirstName, 
            authResult.user.LastName,
            authResult.user.Email, 
            authResult.Token
        );
    }
}