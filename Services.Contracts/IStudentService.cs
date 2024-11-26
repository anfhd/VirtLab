using Entities.DTO;
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
        void CreateStudent(UserForRegistrationDto user);
        Task<IEnumerable<Course>> GetCoursesForStudentAsync(Guid studentId, bool trackChanges);
        Task<IEnumerable<Project>> GetAllStudentProjectsAsync(Guid studentId, bool trackChanges);
        Task<IEnumerable<Project>> GetOwnedStudentProjectsAsync(Guid studentId, bool trackChanges);
        Task<IEnumerable<Project>> GetParticipatedStudentProjectsAsync(Guid studentId, bool trackChanges);
        Task<IEnumerable<Assignment>> GetStudentAssignmentsAsync(Guid studentId, bool trackChanges);
    }
}
