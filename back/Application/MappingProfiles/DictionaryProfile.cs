using AutoMapper;
using Application.DTOs;
using Domain.Entities;

namespace Application.MappingProfiles;

public class DictionaryProfile : Profile
{
    public DictionaryProfile()
    {
        CreateMap<DictionaryItem, DictionaryItemDTO>()
            .ForMember(dest => dest.ItemStatusId, opt => opt.MapFrom(src => src.Id));
    }
}
