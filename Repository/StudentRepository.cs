using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class StudentRepository: RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
            
        }

        public void CreateStudent(Student student) => Create(student);

        public IEnumerable<Student> GetAllStudents(bool trackChanges) =>
           FindAll(trackChanges)
           .OrderBy(s => s.Id)
           .ToList();

        public Student GetStudent(Guid studentId, bool trackChanges) =>
            FindByCondition(s => s.Id.Equals(studentId), trackChanges)
            .SingleOrDefault();
    }
}
