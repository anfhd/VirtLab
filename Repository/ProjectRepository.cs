using Contracts;
using Entities.Models;
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

        public IEnumerable<Project> GetAllProjects(bool trackChanges) =>
           FindAll(trackChanges)
           .OrderBy(p => p.Name)
           .ToList();

        public Project GetProject(Guid projectId, bool trackChanges) =>
            FindByCondition(p => p.Id.Equals(projectId), trackChanges)
            .SingleOrDefault();
    }
}
