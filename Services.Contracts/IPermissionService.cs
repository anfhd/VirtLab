using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IPermissionService
    {
        Task CreatePermissionAsync(Guid projectId, Guid studentId, UserPermissionForCreationDto permission);
        Task DeletePermissionAsync(Guid permissionId);
        Task UpdatePermissionAsync(Guid projectId, Guid studentId, Guid permissionId, UserPermissionForUpdateDto permission);
        Task<IEnumerable<UserPermission>> GetPermissionsForProjectAsync(Guid projectId, bool trackChanges);
        Task<IEnumerable<UserPermission>> GetProjectsPermissionsForStudentAsync(Guid studentId, bool trackChanges);
    }
}
