using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges);
        Task<Student> GetStudentAsync(Guid studentId, bool trackChanges);
        Task CreateStudentAsync(Student student);
        Task<IEnumerable<Course>> GetCoursesForStudentAsync(Guid studentId, bool trackChanges);
        Task<IEnumerable<Project>> GetStudentOwnedProjectsAsync(Guid studentId, bool trackChanges);
        Task<IEnumerable<Project>> GetStudentParticipatedProjectsAsync(Guid studentId, bool trackChanges);
        Task<IEnumerable<Assignment>> GetStudentAssignmentsAsync(Guid studentId, bool trackChanges);
    }
}
