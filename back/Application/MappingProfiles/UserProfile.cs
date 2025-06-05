using AutoMapper;
using Application.DTOs;
using Domain.Entities;

namespace Application.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDTO>();
    }
}
