﻿using AutoMapper;
using Entities.DTO;
using Entities.Models;


namespace VirtLab
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<UserForRegistrationDto, Student>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Group, opt => opt.Ignore())
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId));

            CreateMap<UserForRegistrationDto, Teacher>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src =>
                src.Courses != null
                ? src.Courses.Select(course => new Course { Name = course }).ToList()
                : null));

            CreateMap<ProjectForCreationDto, Project>();
            CreateMap<ProjectForUpdateDto, Project>();
            CreateMap<MarkForCreationDTO, Mark>();
            CreateMap<FeedbackForCreationDto, Feedback>();
            CreateMap<UserPermissionForCreationDto, UserPermission>();
            CreateMap<UserPermissionForUpdateDto, UserPermission>();
            CreateMap<FileForCreationDTO, Entities.Models.File>();
            CreateMap<FileForUpdateDto, Entities.Models.File>();
            CreateMap<CommentForCreationDTO, Comment>();
            CreateMap<CommentForUpdateDTO, Comment>();
        }
    }
}
