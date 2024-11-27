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
        Task<IEnumerable<Assignment>> GetCourseAssignmentsAsync(Guid courseId, bool trackChanges);
        Task<Course> GetCourseAsync(Guid courseId, bool trackChanges);
        Task<Assignment> GetAssignmentAsync(Guid assignmentId, bool trackChanges);

    }
}
