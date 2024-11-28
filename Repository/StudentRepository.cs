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

        public async Task CreateStudentAsync(Student student) => Create(student);


        public async Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges) =>
           await FindAll(trackChanges)
            .Include(s=>s.User)
            .Include(s=>s.Group)
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
            .SelectMany(c => c.Assignments).Include(a=>a.Deadline)
            .ToListAsync();

        public async Task<Student> GetStudentAsync(Guid studentId, bool trackChanges) =>
            await FindByCondition(s => s.Id.Equals(studentId), trackChanges).Include(s=>s.User)
            .Include(s => s.Group)
            .SingleOrDefaultAsync();

        public async Task<Student> GetStudentByBaseUserIdAsync(string userId, bool trackChanges) =>
            await FindByCondition(s => s.UserId.Equals(userId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Project>> GetStudentOwnedProjectsAsync(Guid studentId, bool trackChanges) =>
            await FindByCondition(s => s.Id.Equals(studentId), trackChanges)
            .Include(s => s.OwnedProjects)
            .ThenInclude(op => op.Technologies)
            .Include(s => s.OwnedProjects)
            .ThenInclude(op => op.ProgrammingLanguages)
            .Include(s => s.OwnedProjects)
            .ThenInclude(op=>op.Participants)
            .ThenInclude(p=>p.User)
            .Include(s => s.OwnedProjects)
            .ThenInclude(op => op.Owner)
            .ThenInclude(s=>s.User)
            .Include(s => s.OwnedProjects)
            .ThenInclude(op=>op.Assignment)
            .ThenInclude(a=>a.Course)
            .ThenInclude(c=>c.Groups)
            .Include(s => s.OwnedProjects)
            .ThenInclude(op => op.Mark)
            .Include(s => s.OwnedProjects)
            .ThenInclude(op => op.Feedbacks)
            .SelectMany(s => s.OwnedProjects)
            .ToListAsync();

        public async Task<IEnumerable<Project>> GetStudentParticipatedProjectsAsync(Guid studentId, bool trackChanges) =>
            await FindByCondition(s => s.Id.Equals(studentId), trackChanges)
            .Include(s => s.ParticipatedProjects)
            .ThenInclude(pp => pp.Technologies)
            .Include(s => s.ParticipatedProjects)
            .ThenInclude(pp => pp.ProgrammingLanguages)
            .Include(s => s.ParticipatedProjects)
            .ThenInclude(op => op.Participants)
            .ThenInclude(p => p.User)
            .Include(s => s.ParticipatedProjects)
            .ThenInclude(op => op.Owner)
            .ThenInclude(s => s.User)
            .Include(s => s.ParticipatedProjects)
            .ThenInclude(op => op.Assignment)
            .ThenInclude(a => a.Course)
            .ThenInclude(c => c.Groups)
            .Include(s => s.ParticipatedProjects)
            .ThenInclude(op => op.Mark)
            .Include(s => s.ParticipatedProjects)
            .ThenInclude(op => op.Feedbacks)
            .SelectMany(s => s.ParticipatedProjects)
            .ToListAsync();
    }
}
