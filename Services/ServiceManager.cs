using Contracts;
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

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _languageService = new Lazy<IProgrammingLanguageService>(() =>
                new ProgrammingLanguageService(repositoryManager, logger));
            _projectService = new Lazy<IProjectService>(()
                => new ProjectService(repositoryManager, logger));
            _studentService = new Lazy<IStudentService>(()
                => new StudentService(repositoryManager, logger));
            _technologyService = new Lazy<ITechnologyService>(()
                => new TechnologyService(repositoryManager, logger));
        }

        public IProgrammingLanguageService ProgrammingLanguageService => _languageService.Value;
        public IProjectService ProjectService => _projectService.Value;
        public IStudentService StudentService => _studentService.Value;
        public ITechnologyService TechnologyService => _technologyService.Value;
    }
}
