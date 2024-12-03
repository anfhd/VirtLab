using System;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace VirtLab.Presentation.Controllers
{
    [Route("api/teachers")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IServiceManager _service;

        public TeachersController(IServiceManager service) => _service = service;

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetTeachers()
        {
            var teachers = await _service.TeacherService.GetAllTeachersAsync(trackChanges: false);

            return Ok(teachers);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetTeacher(Guid id)
        {
            var teacher = await _service.TeacherService.GetTeacherAsync(id, trackChanges: false);

            return Ok(teacher);
        }

        [HttpGet("{id:guid}/courses")]
        [Authorize]
        public async Task<IActionResult> GetTeacherCourses(Guid id)
        {
            var courses = await _service.TeacherService.GetCoursesForTeacherAsync(id, trackChanges: false);

            return Ok(courses);
        }

        [HttpGet("{id:guid}/projects")]
        [Authorize]
        public async Task<IActionResult> GetTeacherProjects(Guid id)
        {
            var projects = await _service.TeacherService.GetProjectsForTeacherAsync(id, trackChanges: false);

            return Ok(projects);
        }
    }
}
