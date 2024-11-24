using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync(bool trackChanges);
        Task<Project> GetProjectAsync(Guid projectId, bool trackChanges);
    }
}
