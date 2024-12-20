﻿using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync(bool trackChanges);
        Task<Project> GetProjectAsync(Guid projectId, bool trackChanges);
        Task<IEnumerable<Technology>> GetProjectTechnologiesAsync(Guid projectId, bool trackChanges);
        Task<IEnumerable<ProgrammingLanguage>> GetProjectLanguagesAsync(Guid projectId, bool trackChanges);
        Task CreateProjectAsync(ProjectForCreationDto project);
        Task UpdateProjectAsync(Guid projectId, ProjectForUpdateDto project, bool trackChanges);
        Task DeleteProjectAsync(Guid projectId, bool trackChanges);
        Task RestoreProjectAsync(Guid projectId, bool trackChanges);
    }
}
