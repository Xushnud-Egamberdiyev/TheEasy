using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
