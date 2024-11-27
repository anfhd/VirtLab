using AutoMapper;
using Contracts;
using Entities.DTO;
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
        private readonly IMapper _mapper;

        public ProjectService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task CreateProjectAsync(ProjectForCreationDto project)
        {
            var projectEntity = _mapper.Map<Project>(project);
            projectEntity.Owner = await _repository.Student.GetStudentAsync(project.OwnerId, true);
            projectEntity.Assignment = await _repository.Course.GetAssignmentAsync(project.AssignmentId, true);
            var technologies = await _repository.Technology.GetAllTechnologiesAsync(true);
            var languages = await _repository.ProgrammingLanguage.GetAllProgrammingLanguagesAsync(false);
            var participants = await _repository.Student.GetAllStudentsAsync(true);

            if(project.TechnologyIds != null) projectEntity.Technologies = technologies.Where(t => project.TechnologyIds.Contains(t.Id)).ToList();
            if (project.ProgrammingLanguageIds != null) projectEntity.ProgrammingLanguages = languages.Where(l => project.ProgrammingLanguageIds.Contains(l.Id)).ToList();
            if (project.ParticipantIds != null) projectEntity.Participants = participants.Where(p => project.ParticipantIds.Contains(p.Id)).ToList();

            await _repository.Project.CreateProject(projectEntity);
            await _repository.SaveAsync();
        }

        public async Task DeleteProjectAsync(Guid projectId, bool trackChanges)
        {
            var projectEntity = await _repository.Project.GetProjectAsync(projectId, trackChanges);

            if (projectEntity is null) throw new ProjectNotFoundException(projectId);

            projectEntity.IsDeleted = true;

            await _repository.SaveAsync();
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

        public async Task RestoreProjectAsync(Guid projectId, bool trackChanges)
        {
            var projectEntity = await _repository.Project.GetDeletedProjectAsync(projectId, trackChanges);

            if (projectEntity is null) throw new ProjectNotFoundException(projectId);

            projectEntity.IsDeleted = false;

            await _repository.SaveAsync();
        }

        public async Task UpdateProjectAsync(Guid projectId, ProjectForUpdateDto project, bool trackChanges)
        {
            var projectEntity = await _repository.Project.GetProjectAsync(projectId, trackChanges);

            if (projectEntity is null) throw new ProjectNotFoundException(projectId);


            projectEntity.Name = project.Name;
            projectEntity.IsAccepted = project.IsAccepted;
            projectEntity.IsSentForReview = project.IsSentForReview;    

            var technologies = await _repository.Technology.GetAllTechnologiesAsync(true);
            var languages = await _repository.ProgrammingLanguage.GetAllProgrammingLanguagesAsync(false);
            var participants = await _repository.Student.GetAllStudentsAsync(true);

            if (project.TechnologyIds != null)
            {
                var existingTechnologies = projectEntity.Technologies.ToList();
                var newTechnologies = technologies.Where(t => project.TechnologyIds.Contains(t.Id)).ToList();

                // Додаємо нові
                foreach (var tech in newTechnologies)
                {
                    if (!existingTechnologies.Contains(tech))
                        projectEntity.Technologies.Add(tech);
                }

                // Видаляємо ті, що більше не потрібні
                foreach (var tech in existingTechnologies)
                {
                    if (!newTechnologies.Contains(tech))
                        projectEntity.Technologies.Remove(tech);
                }
            }

            if (project.ProgrammingLanguageIds != null)
            {
                var existingLanguages = projectEntity.ProgrammingLanguages.ToList();
                var newLanguages = languages.Where(l => project.ProgrammingLanguageIds.Contains(l.Id)).ToList();

                foreach (var lang in newLanguages)
                {
                    if (!existingLanguages.Contains(lang))
                        projectEntity.ProgrammingLanguages.Add(lang);
                }

                foreach (var lang in existingLanguages)
                {
                    if (!newLanguages.Contains(lang))
                        projectEntity.ProgrammingLanguages.Remove(lang);
                }
            }

            if (project.ParticipantIds != null)
            {
                var existingParticipants = projectEntity.Participants.ToList();
                var newParticipants = participants.Where(p => project.ParticipantIds.Contains(p.Id)).ToList();

                foreach (var participant in newParticipants)
                {
                    if (!existingParticipants.Contains(participant))
                        projectEntity.Participants.Add(participant);
                }

                foreach (var participant in existingParticipants)
                {
                    if (!newParticipants.Contains(participant))
                        projectEntity.Participants.Remove(participant);
                }
            }

            await _repository.SaveAsync();
        }
    }
}
