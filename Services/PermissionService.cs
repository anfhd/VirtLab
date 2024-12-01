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
    internal sealed class PermissionService: IPermissionService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PermissionService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task CreatePermissionAsync(Guid projectId, Guid studentId, UserPermissionForCreationDto permission)
        {
            var student = await _repository.Student.GetStudentAsync(studentId, trackChanges: true);
            if (student is null) throw new StudentNotFoundException(studentId);

            var project = await _repository.Project.GetProjectAsync(projectId, trackChanges: true);
            if (project is null) throw new ProjectNotFoundException(projectId);

            var permissionEntity = _mapper.Map<UserPermission>(permission);

            await _repository.Permission.CreatePermissionAsync(permissionEntity);
            await _repository.SaveAsync();
        }

        public async Task DeletePermissionAsync(Guid permissionId)
        {
            var permission = await _repository.Permission.GetPermissionAsync(permissionId, false);

            await _repository.Permission.DeletePermissionAsync(permission);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<UserPermission>> GetPermissionsForProjectAsync(Guid projectId, bool trackChanges)
        {
            var project = await _repository.Project.GetProjectAsync(projectId, trackChanges: true);
            if (project is null) throw new ProjectNotFoundException(projectId);

            var permissions = await _repository.Permission.GetPermissionsForProjectAsync(projectId, trackChanges);

            return permissions;
        }

        public async Task<IEnumerable<UserPermission>> GetProjectsPermissionsForStudentAsync(Guid studentId, bool trackChanges)
        {
            var student = await _repository.Student.GetStudentAsync(studentId, trackChanges: true);
            if (student is null) throw new StudentNotFoundException(studentId);

            var permissions = await _repository.Permission.GetProjectsPermissionsForStudentAsync(studentId, trackChanges);

            return permissions;
        }

        public async Task UpdatePermissionAsync(Guid projectId, Guid studentId, Guid permissionId, UserPermissionForUpdateDto permission)
        {
            var student = await _repository.Student.GetStudentAsync(studentId, trackChanges: false);
            if (student is null) throw new StudentNotFoundException(studentId);

            var project = await _repository.Project.GetProjectAsync(projectId, trackChanges: false);
            if (project is null) throw new ProjectNotFoundException(projectId);

            var permissionEntity = await _repository.Permission.GetPermissionAsync(permissionId, trackChanges: true);
            permissionEntity.CanEdit = permission.CanEdit;
            permissionEntity.CanView = permission.CanView;

            await _repository.SaveAsync();
        }
    }
}
