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
    public class PermissionRepository : RepositoryBase<UserPermission>, IPermissionRepository
    {
        public PermissionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreatePermissionAsync(UserPermission permission) => Create(permission);

        public async Task DeletePermissionAsync(UserPermission permission) => Delete(permission);

        public async Task<UserPermission> GetPermissionAsync(Guid id, bool trackChanges) =>
            await FindByCondition(p => p.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<UserPermission>> GetPermissionsForProjectAsync(Guid projectId, bool trackChanges) =>
            await FindByCondition(p => p.ProjectId.Equals(projectId), trackChanges)
            .ToListAsync();

        public async Task<IEnumerable<UserPermission>> GetProjectsPermissionsForStudentAsync(Guid studentId, bool trackChanges) =>
            await FindByCondition(p => p.StudentId.Equals(studentId), trackChanges)
            .ToListAsync();
    }
}
