using QuickBite.Domain.Entities;
using QuickBite.Application.Common.Interfaces.Persistence;
using QuickBite.Application.Common.Interfaces.Persistence.Repositories;

namespace QuickBite.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly List<User>_users = new();

    public void AddUser(User user)
    {
        _users.Add(user);
    }
 
    public User? GetUserByEmail(string email, CancellationToken cancellationToken)
    {
        return _users.FirstOrDefault(u => u.Email == email);
    }
}