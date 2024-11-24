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
        public async Task<IActionResult> GetStudents()
        {
            var students = await _service.StudentService.GetAllStudentsAsync(trackChanges: false);

            return Ok(students);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetStudent(Guid id)
        {
            var student = await _service.StudentService.GetStudentAsync(id, trackChanges: false);

            return Ok(student);
        }

        [HttpGet("{id:guid}/courses")]
        public async Task<IActionResult> GetStudentCourses(Guid id)
        {
            var courses = await _service.StudentService.GetCoursesForStudentAsync(id, trackChanges: false);

            return Ok(courses);
        }
    }
}
