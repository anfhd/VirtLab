using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync(bool trackChanges);
        Task<IEnumerable<Assignment>> GetCourseAssignmentsAsync(Guid courseId, bool trackChanges);
        Task<Course> GetCourseAsync(Guid courseId, bool trackChanges);
        Task<Assignment> GetAssignmentAsync(Guid courseId, Guid assignmentId, bool trackChanges);
    }
}
