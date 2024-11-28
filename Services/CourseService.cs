using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class CourseService: ICourseService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public CourseService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync(bool trackChanges)
        {
            var courses = await _repository.Course.GetAllCoursesAsync(trackChanges);

            return courses;
        }

        public async Task<Course> GetCourseAsync(Guid courseId, bool trackChanges)
        {
            var course = await _repository.Course.GetCourseAsync(courseId, trackChanges);

            if (course is null) throw new CourseNotFoundException(courseId);

            return course;
        }

        public async Task<IEnumerable<Assignment>> GetCourseAssignmentsAsync(Guid courseId, bool trackChanges)
        {
            var course = await _repository.Course.GetCourseAsync(courseId, trackChanges);

            if (course is null) throw new CourseNotFoundException(courseId);

            var courseAssignments = await _repository.Course.GetCourseAssignmentsAsync(courseId, trackChanges);

            return courseAssignments;
        }

        public async Task<Assignment> GetAssignmentAsync(Guid assignmentId, bool trackChanges)
        {

            var assignment = await _repository.Course.GetAssignmentAsync(assignmentId, trackChanges);

            return assignment;
        }
    }
}
