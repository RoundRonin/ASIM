using Domain.Entities;
using Application.DTOs;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface ITestService
{
    Task<TestDTO> GetTestByIdAsync(int id);
    Task<TestDTO> AddTestAsync(CreateTestDTO createTestDTO);
}