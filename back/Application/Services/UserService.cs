using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
{
    public async Task<string> LoginAsync(string username, string password)
    {
        var user = await userRepository.GetByUsernameAsync(username);
        if (user == null || user.PasswordHash != password) // In real apps, hash+salt!
            throw new UnauthorizedAccessException("Invalid credentials.");

        return "token_xyz"; // In real apps, return JWT
    }

    public Task LogoutAsync() => Task.CompletedTask;

    public async Task<UserDTO> GetUserByUsernameAsync(string username)
    {
        var user = await userRepository.GetByUsernameAsync(username);
        return user != null ? mapper.Map<UserDTO>(user) : throw new Exception("User not found");
    }

    public async Task<int> AddToBlacklistAsync(string username)
    {
        return await userRepository.AddToBlacklistAsync(username);
    }

    public async Task RemoveFromBlacklistAsync(string username)
    {
        await userRepository.RemoveFromBlacklistAsync(username);
    }
}
