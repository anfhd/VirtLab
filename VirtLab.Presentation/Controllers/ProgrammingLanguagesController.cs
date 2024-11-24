using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtLab.Presentation.Controllers
{
    [Route("api/programmingLanguages")]
    [ApiController]
    public class ProgrammingLanguagesController: ControllerBase
    {
        private readonly IServiceManager _service;

        public ProgrammingLanguagesController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetProgrammingLanguages()
        {
            var programmingLanguages = await _service.ProgrammingLanguageService.GetAllProgrammingLanguagesAsync(trackChanges: false);

            return Ok(programmingLanguages);
        }
        
    }
}
