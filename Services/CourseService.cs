using Contracts;
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

        public IEnumerable<Course> GetAllCourses(bool trackChanges)
        {
            var courses = _repository.Course.GetAllCourses(trackChanges);

            return courses;
        }
    }
}
