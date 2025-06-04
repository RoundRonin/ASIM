using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserDomainService
{
    Task<User> GetUserByUsernameAsync(string username);
    Task<string> LoginAsync(string username, string password);
    Task LogoutAsync();
    Task<int> AddToBlacklistAsync(string username);
    Task RemoveFromBlacklistAsync(string username);
}
