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
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CoursesController(IServiceManager service) => _service = service;

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _service.CourseService.GetAllCoursesAsync(trackChanges: false);

            return Ok(courses);
        }

        [HttpGet("{id:guid}/assignments")]
        [Authorize]
        public async Task<IActionResult> GetCourseAssignments(Guid id)
        {
            var courseAssignments = await _service.CourseService.GetCourseAssignmentsAsync(id, trackChanges: false);

            return Ok(courseAssignments);
        }

        [HttpGet("/assignments/{assignmentId:guid}")]
        [Authorize]
        public async Task<IActionResult> GetAssignment(Guid assignmentId)
        {
            var assignment = await _service.CourseService.GetAssignmentAsync(assignmentId, trackChanges: false);

            return Ok(assignment);
        }
    }
}
