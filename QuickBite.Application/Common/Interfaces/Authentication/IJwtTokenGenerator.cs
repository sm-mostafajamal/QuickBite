using QuickBite.Domain.Entities;

namespace QuickBite.Application.Common.interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}

