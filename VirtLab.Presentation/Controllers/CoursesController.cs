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
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _service.CourseService.GetAllCoursesAsync(trackChanges: false);

            return Ok(courses);
        }

        [HttpGet("{id:guid}/assignments")]
        public async Task<IActionResult> GetCourseAssignments(Guid id)
        {
            var courseAssignments = await _service.CourseService.GetCourseAssignmentsAsync(id, trackChanges: false);

            return Ok(courseAssignments);
        }

        [HttpGet("{courseId:guid}/assignments/{assignmentId:guid}")]
        public async Task<IActionResult> GetAssignment(Guid courseId, Guid assignmentId)
        {
            var assignment = await _service.CourseService.GetAssignmentAsync(courseId, assignmentId, trackChanges: false);

            return Ok(assignment);
        }
    }
}
