using AutoMapper;
using Entities.DTO;
using Entities.Models;

namespace VirtLab
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<UserForRegistrationDto, Student>();
            CreateMap<UserForRegistrationDto, Teacher>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src =>
                src.Courses != null
                ? src.Courses.Select(course => new Course { Name = course }).ToList()
                : null));
        }
    }
}
