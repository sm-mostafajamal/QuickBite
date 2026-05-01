using QuickBite.Domain.Entities;

namespace QuickBite.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    void AddUser(User user);
    User? GetUserByEmail(string email);
}