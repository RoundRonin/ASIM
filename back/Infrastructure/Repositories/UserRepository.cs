using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository(AppDbContext db) : IUserRepository
{
    public async Task<User> GetByUsernameAsync(string username)
    {
        return await db.Users.FirstOrDefaultAsync(u => u.Name == username);
    }

    public async Task<int> AddToBlacklistAsync(string username)
    {
        var user = await GetByUsernameAsync(username);
        if (user == null) throw new Exception("User not found");

        var entry = new BlacklistEntry
        {
            UserId = user.UserId,
            RevokedAt = DateTime.UtcNow,
            Reason = "Manually added"
        };

        db.BlacklistEntries.Add(entry);
        await db.SaveChangesAsync();
        return entry.BlacklistId;
    }

    public async Task RemoveFromBlacklistAsync(string username)
    {
        var user = await GetByUsernameAsync(username);
        if (user == null) throw new Exception("User not found");

        var entry = await db.BlacklistEntries.FirstOrDefaultAsync(b => b.UserId == user.UserId);
        if (entry == null) throw new Exception("User is not blacklisted");

        db.BlacklistEntries.Remove(entry);
        await db.SaveChangesAsync();
    }
}
