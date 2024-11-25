using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
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


        public async Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges) =>
           await FindAll(trackChanges)
           .OrderBy(s => s.Id)
           .ToListAsync();

        public async Task<IEnumerable<Course>> GetCoursesForStudentAsync(Guid studentId, bool trackChanges) =>
            await FindByCondition(s => s.Id.Equals(studentId), trackChanges)
            .Include(s => s.Group)
            .ThenInclude(g => g.Courses)
            .Select(s => s.Group)
            .SelectMany(g => g.Courses)
            .ToListAsync();

        public async Task<IEnumerable<Assignment>> GetStudentAssignmentsAsync(Guid studentId, bool trackChanges) =>
            await FindByCondition(s => s.Id.Equals(studentId), trackChanges)
            .Include(s => s.Group)
            .ThenInclude(g => g.Courses)
            .ThenInclude(c => c.Assignments)
            .Select(s => s.Group)
            .SelectMany(g => g.Courses)
            .SelectMany(c => c.Assignments)
            .ToListAsync();

        public async Task<Student> GetStudentAsync(Guid studentId, bool trackChanges) =>
            await FindByCondition(s => s.Id.Equals(studentId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Project>> GetStudentOwnedProjectsAsync(Guid studentId, bool trackChanges) =>
            await FindByCondition(s => s.Id.Equals(studentId), trackChanges)
            .Include(s => s.OwnedProjects)
            .ThenInclude(op => op.Technologies)
            .Include(s => s.OwnedProjects)
            .ThenInclude(op => op.ProgrammingLanguages)
            .SelectMany(s => s.OwnedProjects)
            .ToListAsync();

        public async Task<IEnumerable<Project>> GetStudentParticipatedProjectsAsync(Guid studentId, bool trackChanges) =>
            await FindByCondition(s => s.Id.Equals(studentId), trackChanges)
            .Include(s => s.ParticipatedProjects)
            .ThenInclude(pp => pp.Technologies)
            .Include(s => s.OwnedProjects)
            .ThenInclude(pp => pp.ProgrammingLanguages)
            .SelectMany(s => s.ParticipatedProjects)
            .ToListAsync();
    }
}
