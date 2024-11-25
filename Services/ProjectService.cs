using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class ProjectService: IProjectService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public ProjectService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync(bool trackChanges)
        {
            var projects = await _repository.Project.GetAllProjectsAsync(trackChanges);

            return projects;
        }

        public async Task<Project> GetProjectAsync(Guid projectId, bool trackChanges)
        {
            var project = await _repository.Project.GetProjectAsync(projectId, trackChanges);

            if (project is null) throw new ProjectNotFoundException(projectId);

            return project;
        }

        public async Task<IEnumerable<ProgrammingLanguage>> GetProjectLanguagesAsync(Guid projectId, bool trackChanges)
        {
            var project = await _repository.Project.GetProjectAsync(projectId, trackChanges);

            if (project is null) throw new ProjectNotFoundException(projectId);

            var programmingLanguages = await _repository.Project.GetProjectLanguagesAsync(projectId, trackChanges);

            return programmingLanguages;
        }

        public async Task<IEnumerable<Technology>> GetProjectTechnologiesAsync(Guid projectId, bool trackChanges)
        {
            var project = await _repository.Project.GetProjectAsync(projectId, trackChanges);

            if (project is null) throw new ProjectNotFoundException(projectId);

            var technologies = await _repository.Project.GetProjectTechnologiesAsync(projectId, trackChanges);

            return technologies;
        }
    }
}
