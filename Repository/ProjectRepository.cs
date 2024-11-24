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
    }
}
