using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Services;

public class UserDomainService(IUserRepository userRepository) : IUserDomainService
{
    public async Task<User> GetUserByUsernameAsync(string username)
    {
        return await userRepository.GetByUsernameAsync(username);
    }

    public async Task<string> LoginAsync(string username, string password)
    {
        var user = await userRepository.GetByUsernameAsync(username);
        if (user == null || user.PasswordHash != password)
            throw new UnauthorizedAccessException("Invalid credentials.");

        return "token_xyz"; // заглушка, в реальности — JWT
    }

    public Task LogoutAsync() => Task.CompletedTask;

    public async Task<int> AddToBlacklistAsync(string username)
    {
        return await userRepository.AddToBlacklistAsync(username);
    }

    public async Task RemoveFromBlacklistAsync(string username)
    {
        await userRepository.RemoveFromBlacklistAsync(username);
    }
}
