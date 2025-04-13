using Domain.Entities;

namespace Domain.Interfaces;

public interface ITestDomainService
{
    public Task<Test> AddTestAsync(Test test);
    public Task<Test> GetTestByIdAsync(int id);
}