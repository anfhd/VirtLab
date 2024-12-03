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

        public async Task CreateProject(Project project) => Create(project);

        public async Task<IEnumerable<Project>> GetAllProjectsAsync(bool trackChanges) =>
           await FindByCondition((p => !p.IsDeleted), trackChanges)
           .Include(p => p.ProgrammingLanguages)
            .Include(p => p.Participants)
            .Include(p => p.Technologies)
            .Include(p => p.Feedbacks)
            .Include(p => p.Owner)
            .Include(p => p.Assignment)
            .Include(p => p.Mark)
            .Include(p => p.Files)
            .ThenInclude(f => f.Versions)
            .Include(p => p.Files)
            .ThenInclude(f => f.Comments)
            .Include(p => p.Permissions)
           .ToListAsync();

        public async Task<Project> GetDeletedProjectAsync(Guid projectId, bool trackChanges) =>
            await FindByCondition(p => p.Id.Equals(projectId) && p.IsDeleted, trackChanges)
            .Include(p => p.ProgrammingLanguages)
            .Include(p => p.Participants)
            .Include(p => p.Technologies)
            .Include(p => p.Feedbacks)
            .Include(p => p.Owner)
            .Include(p => p.Assignment)
            .Include(p => p.Mark)
            .Include(p => p.Files)
            .ThenInclude(f => f.Versions)
            .Include(p => p.Files)
            .ThenInclude(f => f.Comments)
            .Include(p => p.Permissions)
            .SingleOrDefaultAsync();

        public async Task<Project> GetProjectAsync(Guid projectId, bool trackChanges) =>
            await FindByCondition(p => p.Id.Equals(projectId) && !p.IsDeleted, trackChanges)
            .Include(p => p.ProgrammingLanguages)
            .Include(p => p.Participants)
            .ThenInclude(p => p.User)
            .Include(p => p.Technologies)
            .Include(p => p.Feedbacks)
            .ThenInclude(f=>f.Teacher)
            .ThenInclude(t=>t.User)
            .Include(p => p.Owner)
            .ThenInclude(o=>o.User)
            .Include(p => p.Assignment)
            .Include(p => p.Files)
            .ThenInclude(f => f.Versions)
            .Include(p => p.Files)
            .ThenInclude(f => f.Comments)
            .Include(p => p.Permissions)
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
