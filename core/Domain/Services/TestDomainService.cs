using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Domain.Services;

public class TestDomainService(ITestRepository testRepository) : ITestDomainService
{
    private readonly ITestRepository testRepository = testRepository;

    public async Task<Test> AddTestAsync(Test test)
    {

        test.Text = Guid.NewGuid().ToString();

        var newText = await testRepository.AddAsync(test);
        return newText;
    }

    public async Task<Test> GetTestByIdAsync(int id)
    {
        var order = await testRepository.GetByIdAsync(id);
        if (order == null)
        {
            throw new EntityNotFoundException($"Order with ID {id} not found.");
        }

        return order;
    }
}

