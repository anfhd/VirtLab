using Entities.DTO;
using Entities.Exceptions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllTeachersAsync(bool trackChanges);
        Task<Teacher> GetTeacherAsync(Guid teacherId, bool trackChanges);
        Task CreateTeacherAsync(Teacher teacher);
        Task CreateTeacherAsync(UserForRegistrationDto user, User baseUser);
        Task<IEnumerable<Course>> GetCoursesForTeacherAsync(Guid teacherId, bool trackChanges);
        Task<Teacher> GetTeacherByBaseUserIdAsync(string userId, bool trackChanges);
        Task<IEnumerable<Project>> GetProjectsForTeacherAsync(Guid teacherId, bool trackChanges);
    }
}
