using Entities.DTO;
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
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _service.ProjectService.GetAllProjectsAsync(trackChanges: false);

            return Ok(projects);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProject(Guid id)
        {
            var project = await _service.ProjectService.GetProjectAsync(id, trackChanges: false);
            return Ok(project);
        }

        [HttpGet("{id:guid}/technologies")]
        public async Task<IActionResult> GetProjectTechnologies(Guid id)
        {
            var projectTechnologies = await _service.ProjectService.GetProjectTechnologiesAsync(id, trackChanges: false);

            return Ok(projectTechnologies);
        }

        [HttpGet("{id:guid}/programmingLanguages")]
        public async Task<IActionResult> GetProjectProgrammingLanguages(Guid id)
        {
            var projectProgrammingLanguages = await _service.ProjectService.GetProjectLanguagesAsync(id, trackChanges: false);

            return Ok(projectProgrammingLanguages);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] ProjectForCreationDto project)
        {
            if (project is null) return BadRequest("Project object is null!");

            await _service.ProjectService.CreateProjectAsync(project);

            return StatusCode(201);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            await _service.ProjectService.DeleteProjectAsync(id, trackChanges: true);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProject(Guid id, [FromBody] ProjectForUpdateDto project)
        {
            await _service.ProjectService.UpdateProjectAsync(id, project, trackChanges: true);

            return NoContent();
        }

        [HttpPost("{id:guid}/mark")]
        public async Task<IActionResult> CreateMarkForProject(Guid id, [FromBody] MarkForCreationDTO mark)
        {
            await _service.MarkService.CreateMarkForProjectAsync(mark);

            return StatusCode(201);
        }

        [HttpPut("{id:guid}/restore")]
        public async Task<IActionResult> RestoreProject(Guid id)
        {
            await _service.ProjectService.RestoreProjectAsync(id, trackChanges: true);

            return NoContent();
        }
    }
}
