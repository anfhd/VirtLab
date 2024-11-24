using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TeacherRepository: RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public void CreateTeacher(Teacher teacher) => Create(teacher);

        public IEnumerable<Teacher> GetAllTeachers(bool trackChanges) =>
            FindAll(trackChanges)
            .ToList();

        public Teacher GetTeacher(int teacherId, bool trackChanges) =>
            FindByCondition(t => t.Id.Equals(teacherId), trackChanges)
            .SingleOrDefault();
    }
}
