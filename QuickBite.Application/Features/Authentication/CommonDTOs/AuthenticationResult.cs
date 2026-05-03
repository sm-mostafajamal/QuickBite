namespace QuickBite.Application.Features.Authentication.CommonDTOs;

using QuickBite.Domain.Entities;

public record AuthenticationResult(
    Guid Id,
    string FirstName, 
    string LastName, 
    string Email, 
    string Token
);