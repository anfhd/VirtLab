using Contracts;
using Entities.Models;

namespace Repository;

public class StudentRepository(RepositoryContext repositoryContext)
    : RepositoryBase<Student>(repositoryContext), IStudentRepository
{
    /* TODO: Implement async versions later */
    public void CreateStudent(Student student) => Create(student);

    public IEnumerable<Student> GetAllStudents(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(s => s.Id)
            .ToList();

    public Student GetStudent(Guid studentId, bool trackChanges) =>
        FindByCondition(s => s.Id.Equals(studentId), trackChanges)
            .SingleOrDefault();
}