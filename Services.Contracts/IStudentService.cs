using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges);
        Task<Student> GetStudentAsync(Guid studentId, bool trackChanges);
        void CreateStudent(Student student);
        Task<IEnumerable<Course>> GetCoursesForStudentAsync(Guid studentId, bool trackChanges);
        Task<IEnumerable<Project>> GetAllStudentProjectsAsync(Guid studentId, bool trackChanges);
        Task<IEnumerable<Project>> GetOwnedStudentProjectsAsync(Guid studentId, bool trackChanges);
        Task<IEnumerable<Project>> GetParticipatedStudentProjectsAsync(Guid studentId, bool trackChanges);
    }
}
