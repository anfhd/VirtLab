﻿using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class ServiceManager: IServiceManager
    {
        private readonly Lazy<IProgrammingLanguageService> _languageService;
        private readonly Lazy<IProjectService> _projectService;
        private readonly Lazy<IStudentService> _studentService;
        private readonly Lazy<ITechnologyService> _technologyService;
        private readonly Lazy<ICourseService> _courseService;
        private readonly Lazy<IGroupService> _groupService;
        private readonly Lazy<ITeacherService> _teacherService;
        private readonly Lazy<IFeedbackService> _feedbackService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IMarkService> _markService;

        public ServiceManager(
            IRepositoryManager repositoryManager,
            ILoggerManager logger,
            IMapper mapper,
            UserManager<User> userManager,
            IConfiguration configuration
            )
        {
            _languageService = new Lazy<IProgrammingLanguageService>(() 
                => new ProgrammingLanguageService(repositoryManager, logger));
            _projectService = new Lazy<IProjectService>(()
                => new ProjectService(repositoryManager, logger, mapper));
            _studentService = new Lazy<IStudentService>(()
                => new StudentService(repositoryManager, logger, mapper));
            _technologyService = new Lazy<ITechnologyService>(()
                => new TechnologyService(repositoryManager, logger));
            _courseService = new Lazy<ICourseService>(()
                => new CourseService(repositoryManager, logger));
            _groupService = new Lazy<IGroupService>(()
                => new GroupService(repositoryManager, logger));
            _teacherService = new Lazy<ITeacherService>(()
                => new TeacherService(repositoryManager, logger, mapper));
            _feedbackService = new Lazy<IFeedbackService>(()
                => new FeedbackService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(()
                => new AuthenticationService(logger, mapper, userManager, configuration));
            _markService = new Lazy<IMarkService>(()
                => new MarkService(repositoryManager, logger, mapper));
        }

        public IProgrammingLanguageService ProgrammingLanguageService => _languageService.Value;
        public IProjectService ProjectService => _projectService.Value;
        public IStudentService StudentService => _studentService.Value;
        public ITechnologyService TechnologyService => _technologyService.Value;
        public IGroupService GroupService => _groupService.Value;
        public ITeacherService TeacherService => _teacherService.Value;
        public ICourseService CourseService => _courseService.Value;
        public IFeedbackService FeedbackService => _feedbackService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IMarkService MarkService => _markService.Value;
    }
}
