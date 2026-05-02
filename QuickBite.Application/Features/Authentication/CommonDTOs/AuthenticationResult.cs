using QuickBite.Domain.Entities;

namespace QuickBite.Application.Features.Authentication.CommonDTOs;

public record AuthenticationResult(
    User user, 
    string Token
);