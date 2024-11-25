using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync(bool trackChanges);
        Task<IEnumerable<Assignment>> GetCourseAssignments(Guid courseId, bool trackChanges);
        Task<Course> GetCourse(Guid courseId, bool trackChanges);

    }
}
