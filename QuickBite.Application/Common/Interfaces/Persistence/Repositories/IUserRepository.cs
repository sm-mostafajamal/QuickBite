using QuickBite.Domain.Entities;

namespace QuickBite.Application.Common.Interfaces.Persistence.Repositories;

public interface IUserRepository
{
    void AddUser(User user);
    User? GetUserByEmail(string email, CancellationToken cancellationToken);
}