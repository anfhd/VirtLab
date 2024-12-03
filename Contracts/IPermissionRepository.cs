using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPermissionRepository
    {
        Task CreatePermissionAsync(UserPermission permission);
        Task DeletePermissionAsync(UserPermission permission);
        Task<IEnumerable<UserPermission>> GetPermissionsForProjectAsync(Guid projectId, bool trackChanges);
        Task<IEnumerable<UserPermission>> GetProjectsPermissionsForStudentAsync(Guid studentId, bool trackChanges);
        Task<UserPermission> GetPermissionAsync(Guid id, bool trackChanges);
    }
}
