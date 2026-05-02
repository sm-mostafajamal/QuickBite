using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickBite.Application.Features.Authentication.Commands.Login;
using QuickBite.Application.Features.Authentication.Commands.Register;
using QuickBite.Contracts.Authentication;
using LoginRequest = QuickBite.Contracts.Authentication.LoginRequest;
using RegisterRequest = QuickBite.Contracts.Authentication.RegisterRequest;

namespace QuickBite.API.Controllers;
    
[ApiController]
[Route("api/auth/")]
public class AuthenticationController(ISender sender) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var authResult = await sender.Send(new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password));

        var response = new AuthenticationResponse(
            authResult.user.Id, 
            authResult.user.FirstName, 
            authResult.user.LastName,
            authResult.user.Email, 
            authResult.Token
        );
        
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var authResult = await sender.Send(new LoginCommand(request.Email, request.Password));

        var response = new AuthenticationResponse(
            authResult.user.Id, 
            authResult.user.FirstName, 
            authResult.user.LastName,
            authResult.user.Email, 
            authResult.Token
        );
        
        return Ok(response);
    }
}