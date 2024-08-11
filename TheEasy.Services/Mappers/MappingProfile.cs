using AutoMapper;
using TheEasy.Domain.Entities;
using TheEasy.Services.DTOs.Users;

namespace TheEasy.Services.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserForCreationDto, User>().ReverseMap();
        CreateMap<UserForResultDto, User>().ReverseMap();
        CreateMap<UserForUpdateDto, User>().ReverseMap();
    }
}
