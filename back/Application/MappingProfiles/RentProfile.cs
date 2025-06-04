using AutoMapper;
using Application.DTOs;
using Domain.Entities;

namespace Application.MappingProfiles;

public class RentalProfile : Profile
{
    public RentalProfile()
    {
        CreateMap<CreateRentDTO, Rental>()
            .ForMember(dest => dest.RenterId, opt => opt.MapFrom(src => src.UserId));
        
        CreateMap<Rental, RentDTO>();
    }
}
