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
        IEnumerable<Teacher> GetAllTeachers(bool trackChanges);
        Teacher GetTeacher(int teacherId, bool trackChanges);
        void CreateTeacher(Teacher teacher);
    }
}
