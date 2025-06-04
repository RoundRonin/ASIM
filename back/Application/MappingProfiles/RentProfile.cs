using AutoMapper;
using Application.DTOs;
using Domain.Entities;

namespace Application.MappingProfiles;

public class RentProfile : Profile
{
    public RentProfile()
    {
        CreateMap<CreateRentDTO, Rental>();
        CreateMap<Rental, RentDTO>();
    }
}
