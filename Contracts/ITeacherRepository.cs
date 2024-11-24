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
        IEnumerable<Teacher> GetAllTeachers(bool trackChanges);
        Teacher GetTeacher(int teacherId, bool trackChanges);
        void CreateTeacher(Teacher teacher);
    }
}
