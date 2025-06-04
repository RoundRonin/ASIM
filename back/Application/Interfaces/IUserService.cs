using Application.DTOs;

namespace Application.Interfaces;

public interface IUserService
{
    Task<string> LoginAsync(string username, string password);
    Task LogoutAsync();
    Task<UserDTO> GetUserByUsernameAsync(string username);
    Task<int> AddToBlacklistAsync(string username);
    Task RemoveFromBlacklistAsync(string username);
}
