using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace DemoAPI.Utilities.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseDtoForUpdate, Course>();
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
