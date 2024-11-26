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
    }
}
