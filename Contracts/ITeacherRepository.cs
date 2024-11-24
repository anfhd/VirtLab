using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllTeachersAsync(bool trackChanges);
        Task<Teacher> GetTeacherAsync(Guid teacherId, bool trackChanges);
        void CreateTeacher(Teacher teacher);
        Task<IEnumerable<Course>> GetCoursesForTeacherAsync(Guid teacherId, bool trackChanges);
    }
}
