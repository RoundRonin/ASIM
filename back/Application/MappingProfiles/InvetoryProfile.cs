// Application/MappingProfiles/InventoryProfile.cs
using AutoMapper;
using Application.DTOs;
using Domain.Entities;

namespace Application.MappingProfiles
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<CreateInventoryItemDTO, InventoryObject>()
                .ForMember(dest => dest.AdditionalDetails, opt => opt.MapFrom(src => src.AdditionalDetails));
            
            CreateMap<InventoryObject, InventoryItemDTO>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId))
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.AdditionalDetails));
            
            CreateMap<CreateInventoryItemDetailsDTO, AdditionalObjectDetails>();
            CreateMap<AdditionalObjectDetails, InventoryItemDetailsDTO>();
        }
    }
}
