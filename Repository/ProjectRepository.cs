using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProjectRepository: RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync(bool trackChanges) =>
           await FindAll(trackChanges)
           .OrderBy(p => p.Name)
           .ToListAsync();

        public async Task<Project> GetProjectAsync(Guid projectId, bool trackChanges) =>
            await FindByCondition(p => p.Id.Equals(projectId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<ProgrammingLanguage>> GetProjectLanguagesAsync(Guid projectId, bool trackChanges) =>
             await FindByCondition(p => p.Id.Equals(projectId), trackChanges)
            .Include(p => p.ProgrammingLanguages)
            .SelectMany(p => p.ProgrammingLanguages)
            .ToListAsync();

        public async Task<IEnumerable<Technology>> GetProjectTechnologiesAsync(Guid projectId, bool trackChanges) =>
             await FindByCondition(p => p.Id.Equals(projectId), trackChanges)
            .Include(p => p.Technologies)
            .SelectMany(p => p.Technologies)
            .ToListAsync();
    }
}
