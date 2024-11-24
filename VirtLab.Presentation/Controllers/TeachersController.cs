using System;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtLab.Presentation.Controllers
{
    [Route("api/teachers")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IServiceManager _service;

        public TeachersController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetTeachers()
        {
            var teachers = _service.TeacherService.GetAllTeachers(trackChanges: false);

            return Ok(teachers);
        }
    }
}
