using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> GetTechnologies()
        {
            var technologies = await _service.TechnologyService.GetAllTechnologiesAsync(trackChanges: false);

            return Ok(technologies);
        }
    }
}
