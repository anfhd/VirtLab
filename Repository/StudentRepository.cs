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
            .Include(s => s.Courses)
            .SelectMany(s => s.Courses)
            .ToListAsync();
           

        public async Task<Student> GetStudentAsync(Guid studentId, bool trackChanges) =>
            await FindByCondition(s => s.Id.Equals(studentId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Project>> GetStudentOwnedProjectsAsync(Guid studentId, bool trackChanges) =>
            await FindByCondition(s => s.Id.Equals(studentId), trackChanges)
            .Include(s => s.OwnedProjects)
            .SelectMany(s => s.OwnedProjects)
            .ToListAsync();

        public async Task<IEnumerable<Project>> GetStudentParticipatedProjectsAsync(Guid studentId, bool trackChanges) =>
            await FindByCondition(s => s.Id.Equals(studentId), trackChanges)
            .Include(s => s.ParticipatedProjects)
            .SelectMany(s => s.ParticipatedProjects)
            .ToListAsync();
    }
}
