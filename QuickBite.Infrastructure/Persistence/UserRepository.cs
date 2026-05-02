using QuickBite.Domain.Entities;
using QuickBite.Application.Common.Interfaces.Persistence;

namespace QuickBite.Infrastructure.Persistence;

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