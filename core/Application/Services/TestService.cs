using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services;

public class TestService(ITestDomainService testDomainService, IMapper mapper) : ITestService
{
    private readonly ITestDomainService testDomainService = testDomainService;
    private readonly IMapper mapper = mapper;
     async Task<TestDTO> ITestService.GetTestByIdAsync(int id)
    {
        var test = await testDomainService.GetTestByIdAsync(id);
        return mapper.Map<TestDTO>(test);
    }

    public async Task<TestDTO> AddTestAsync(CreateTestDTO createTestDTO)
    {
        var test = mapper.Map<Test>(createTestDTO);
        test = await testDomainService.AddTestAsync(test);
        return mapper.Map<TestDTO>(test);
    }
}