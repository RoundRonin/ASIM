using AutoMapper;
using Application.DTOs;
using Domain.Entities;

namespace Application.MappingProfiles;

public class RepairProfile : Profile
{
    public RepairProfile()
    {
        CreateMap<RepairRequest, RepairDTO>()
            .ForMember(dest => dest.RepairId, opt => opt.MapFrom(src => src.RequestId));
            
        CreateMap<CreateRepairDTO, RepairRequest>();
    }
}