using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;

namespace Application.Services;

public class UserService(IUserDomainService domain, IMapper mapper) : IUserService
{
    public async Task<string> LoginAsync(string username, string password)
    {
        return await domain.LoginAsync(username, password);
    }

    public async Task LogoutAsync()
    {
        await domain.LogoutAsync();
    }

    public async Task<UserDTO> GetUserByUsernameAsync(string username)
    {
        var user = await domain.GetUserByUsernameAsync(username);
        return mapper.Map<UserDTO>(user);
    }

    public async Task<int> AddToBlacklistAsync(string username)
    {
        return await domain.AddToBlacklistAsync(username);
    }

    public async Task RemoveFromBlacklistAsync(string username)
    {
        await domain.RemoveFromBlacklistAsync(username);
    }
}
