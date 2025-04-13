using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Diagnostics;

namespace Infrastructure.Repositories;

public class TestRepository(IServiceScopeFactory scopedFactroy) : ITestRepository
{
    public async Task<Test> GetByIdAsync(int id)
    {
        using var scope = scopedFactroy.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        return await context.Tests.FindAsync(id);
    }

    public async Task<Test> AddAsync(Test test)
    {
        using var scope = scopedFactroy.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await context.Tests.AddAsync(test);
        await context.SaveChangesAsync();

        return test;
    }

   
    
}