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
        public IActionResult GetProjects()
        {
            try
            {
                var projects = _service.ProjectService.GetAllProjects(trackChanges: false);

                return Ok(projects);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
