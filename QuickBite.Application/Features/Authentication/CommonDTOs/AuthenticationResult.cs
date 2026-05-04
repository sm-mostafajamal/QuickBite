namespace QuickBite.Application.Features.Authentication.CommonDTOs;

using QuickBite.Domain.Entities;

public record AuthenticationResult(
    User User, 
    string Token
);