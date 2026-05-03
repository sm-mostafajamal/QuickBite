namespace QuickBite.API.Controllers;

using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickBite.Application.Features.Authentication.Commands.Login;
using QuickBite.Application.Features.Authentication.Commands.Register;
using QuickBite.Application.Features.Authentication.CommonDTOs;
using QuickBite.Contracts.Authentication;

[Route("api/auth/")]
public class AuthenticationController(ISender sender, IMapper mapper) : ApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = mapper.Map<RegisterCommand>(request);
        var authResult = await sender.Send(command);

        return authResult.Match(
            authResult => Ok(mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var command = mapper.Map<LoginCommand>(request);
        var authResult = await sender.Send(command);

        return authResult.Match(
            authResult => Ok(mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );
    }
}