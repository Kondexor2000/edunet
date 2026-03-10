using AutoMapper;
using Eduworknet.DTOs;
using Eduworknet.Models;

namespace Worknet.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, LoginDto>();
            CreateMap<RegisterDto, ApplicationUser>();
        }
    }
}