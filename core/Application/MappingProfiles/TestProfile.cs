using Application.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;

namespace Application.MappingProfiles
{
    public class TestProfile : Profile
    {
        public TestProfile() {
            CreateMap<CreateTestDTO, Test>();
            CreateMap<Test, TestDTO>();
        }
    }
}
