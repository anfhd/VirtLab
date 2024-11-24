using Contracts;
using Entities.Models;
using Services.Contracts;

namespace Services;

internal sealed class CourseService(IRepositoryManager repository) : ICourseService
{
    public IEnumerable<Course> GetAllCourses(bool trackChanges) => repository.Course.GetAllCourses(trackChanges);
}