using QuickBite.Domain.Entities;

namespace QuickBite.Application.Services.Authentication;

public record AuthenticationResult(
    User user, 
    string Token
);