using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository
{
    Task<User> GetByUsernameAsync(string username);
    Task<int> AddToBlacklistAsync(string username);
    Task RemoveFromBlacklistAsync(string username);
}
