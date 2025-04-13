using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces;

public interface ITestRepository
{
    Task<Test> GetByIdAsync(int id);
    Task<Test> AddAsync(Test test);
}