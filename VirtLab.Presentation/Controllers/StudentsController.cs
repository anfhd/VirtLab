using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtLab.Presentation.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController: ControllerBase
    {
        private readonly IServiceManager _service;

        public StudentsController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetStudents()
        {
            try
            {
                var students = _service.StudentService.GetAllStudents(trackChanges: false);

                return Ok(students);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
