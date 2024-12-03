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

        [HttpGet("{id:guid}/ownedProjects")]
        public async Task<IActionResult> GetStudentOwnedProjects(Guid id)
        {
            var projects = await _service.StudentService.GetOwnedStudentProjectsAsync(id, trackChanges: false);

            return Ok(projects);
        }

        [HttpGet("{id:guid}/participatedProjects")]
        public async Task<IActionResult> GetStudentParticipatedProjects(Guid id)
        {
            var projects = await _service.StudentService.GetParticipatedStudentProjectsAsync(id, trackChanges: false);

            return Ok(projects);
        }

        [HttpGet("{id:guid}/allProjects")]
        public async Task<IActionResult> GetStudentProjects(Guid id)
        {
            var projects = await _service.StudentService.GetAllStudentProjectsAsync(id, trackChanges: false);

            return Ok(projects);
        }

        [HttpGet("{id:guid}/Assignments")]
        public async Task<IActionResult> GetStudentAssignments(Guid id)
        {
            var assignments = await _service.StudentService.GetStudentAssignmentsAsync(id, trackChanges: false);

            return Ok(assignments);
        }

        [HttpGet("{id:guid}/permissions")]
        public async Task<IActionResult> GetStudentPermissions(Guid id)
        {
            var permissions = await _service.PermissionService.GetProjectsPermissionsForStudentAsync(id, trackChanges: false);

            return Ok(permissions);
        }
    }
}
