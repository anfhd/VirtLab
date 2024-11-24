using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtLab.Presentation.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ProjectsController(IServiceManager service) => _service = service;

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
    }
}
