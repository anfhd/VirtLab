using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtLab.Presentation.Controllers
{
    [Route("api/technologies")]
    [ApiController]
    public class TechnologiesController: ControllerBase
    {
        private readonly IServiceManager _service;

        public TechnologiesController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetTechnologies()
        {
            var technologies = _service.TechnologyService.GetAllTechnologies(trackChanges: false);

            return Ok(technologies);
        }
    }
}
