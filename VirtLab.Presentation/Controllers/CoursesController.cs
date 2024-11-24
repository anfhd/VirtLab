using System;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtLab.Presentation.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CoursesController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetCourses()
        {
            var courses = _service.CourseService.GetAllCourses(trackChanges: false);

            return Ok(courses);
        }
    }
}
