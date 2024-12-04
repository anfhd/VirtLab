using Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace VirtLab.Presentation.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ProjectsController(IServiceManager service)
            => _service = service;

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _service.ProjectService.GetAllProjectsAsync(trackChanges: false);

            return Ok(projects);
        }

        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProject(Guid id)
        {
            var project = await _service.ProjectService.GetProjectAsync(id, trackChanges: false);
            return Ok(project);
        }

        [HttpGet("{id:guid}/technologies")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProjectTechnologies(Guid id)
        {
            var projectTechnologies = await _service.ProjectService.GetProjectTechnologiesAsync(id, trackChanges: false);

            return Ok(projectTechnologies);
        }

        [HttpGet("{id:guid}/programmingLanguages")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProjectProgrammingLanguages(Guid id)
        {
            var projectProgrammingLanguages = await _service.ProjectService.GetProjectLanguagesAsync(id, trackChanges: false);

            return Ok(projectProgrammingLanguages);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateProject([FromBody] ProjectForCreationDto project)
        {
            if (project is null) return BadRequest("Project object is null!");

            await _service.ProjectService.CreateProjectAsync(project);

            return StatusCode(201);
        }

        [HttpDelete("{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            await _service.ProjectService.DeleteProjectAsync(id, trackChanges: true);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateProject(Guid id, [FromBody] ProjectForUpdateDto project)
        {
            await _service.ProjectService.UpdateProjectAsync(id, project, trackChanges: true);

            return NoContent();
        }

        [HttpPost("{id:guid}/mark")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateMarkForProject(Guid id, [FromBody] MarkForCreationDTO mark)
        {
            await _service.MarkService.CreateMarkForProjectAsync(mark);

            return StatusCode(201);
        }

        [HttpPut("{id:guid}/restore")]
        [AllowAnonymous]
        public async Task<IActionResult> RestoreProject(Guid id)
        {
            await _service.ProjectService.RestoreProjectAsync(id, trackChanges: true);

            return NoContent();
        }

        [HttpPost("{id:guid}/files")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateFile(Guid id, [FromBody] FileForCreationDTO file)
        {
            await _service.FileService.CreateFileForProjectAsync(id, file);

            return StatusCode(201);
        }

        [HttpGet("{id:guid}/files")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProjectFiles(Guid id)
        {
            var files = await _service.FileService.GetFilesForProjectAsync(id, trackChanges: false);

            return Ok(files);
        }

        [HttpDelete("{projectId:guid}/files/{fileId:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteProjectFile(Guid projectId, Guid fileId)
        {
            await _service.FileService.DeleteFileForProjectAsync(fileId);

            return NoContent();
        }

        [HttpPut("{projectId:guid}/files/{fileId:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateProjectFile(Guid projectId, Guid fileId, [FromBody] FileForUpdateDto file)
        {
            await _service.FileService.UpdateFileAsync(projectId, fileId, file);

            return NoContent();
        }

        [HttpPut("{projectId:guid}/files/{fileId:guid}/versions/{fileVersionId:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> RevertProjectFile(Guid projectId, Guid fileId, Guid fileVersionId)
        {
            await _service.FileService.RestoreFileVersionAsync(projectId, fileId, fileVersionId);

            return NoContent();
        }

        [HttpDelete("{projectId:guid}/files/{fileId:guid}/versions/{fileVersionId:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteProjectFileVersion(Guid projectId, Guid fileId, Guid fileVersionId)
        {
            await _service.FileService.DeleteFileVersionAsync(projectId, fileId, fileVersionId);

            return NoContent();
        }

        [HttpPost("{id:guid}/permissions")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateProjectPermission(Guid id, [FromBody] UserPermissionForCreationDto permission)
        {
            await _service.PermissionService.CreatePermissionAsync(id, permission.StudentId, permission);

            return StatusCode(201);
        }

        [HttpGet("{id:guid}/permissions")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProjectPermissions(Guid id)
        {
            var permissions = await _service.PermissionService.GetPermissionsForProjectAsync(id, trackChanges: false);

            return Ok(permissions);
        }

        [HttpDelete("{projectId:guid}/permissions/{permissionId:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteProjectPermission(Guid projectId, Guid permissionId)
        {
            await _service.PermissionService.DeletePermissionAsync(permissionId);

            return NoContent();
        }

        [HttpPut("{projectId:guid}/permissions/{permissionId:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateProjectPermission(Guid projectId, Guid permissionId, [FromBody]UserPermissionForUpdateDto permission)
        {
            await _service.PermissionService.UpdatePermissionAsync(projectId, permission.StudentId, permissionId, permission);

            return NoContent();
        }

        [HttpPost("{projectId:guid}/files/{fileId:guid}/comments")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateCommentForFile(Guid projectId, Guid fileId, [FromBody]CommentForCreationDTO comment)
        {
            await _service.FileService.CreateCommentForFileAsync(projectId, fileId, comment);

            return StatusCode(201);
        }

        [HttpDelete("{projectId:guid}/files/{fileId:guid}/comments/{commentId:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteCommentForFile(Guid projectId, Guid fileId, Guid commentId)
        {
            await _service.FileService.DeleteCommentForFileAsync(projectId, fileId, commentId);

            return NoContent(); 
        }

        [HttpPut("{projectId:guid}/files/{fileId:guid}/comments/{commentId:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateCommentForFile(Guid projectId, Guid fileId, Guid commentId, [FromBody]CommentForUpdateDTO comment)
        {
            await _service.FileService.UpdateCommentForFileAsync(projectId, fileId, commentId, comment);

            return NoContent();
        }

        [HttpGet("{projectId:guid}/files/{fileId:guid}/comments")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCommentsForFile(Guid projectId, Guid fileId)
        {
            var comments = await _service.FileService.GetAllCommentsForFileAsync(projectId, fileId, trackChanges: false);

            return Ok(comments);
        }
        
        [HttpGet("versions/{versionId:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetVersion(Guid versionId)
        {
            var comments = await _service.FileService.GetVersionAsync(versionId, trackChanges: false);

            return Ok(comments);
        }
    }
}
