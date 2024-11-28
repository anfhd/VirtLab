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
    public class TeacherRepository: RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public async Task CreateTeacherAsync(Teacher teacher) => Create(teacher);

        public async Task<IEnumerable<Project>> GeProjectsForTeacherAsync(Guid teacherId, bool trackChanges) =>
            await FindByCondition(t => t.Id.Equals(teacherId), trackChanges)
            .Include(t => t.Courses)
            .ThenInclude(c => c.Assignments)
            .ThenInclude(a => a.Projects)
            .ThenInclude(p => p.Technologies)
            .Include(t => t.Courses)
            .ThenInclude(c => c.Assignments)
            .ThenInclude(a => a.Projects)
            .ThenInclude(p => p.ProgrammingLanguages)
            .SelectMany(t => t.Courses)
            .SelectMany(c => c.Assignments)
            .SelectMany(a => a.Projects)
            .ToListAsync();

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .ToListAsync();

        public async Task<IEnumerable<Course>> GetCoursesForTeacherAsync(Guid teacherId, bool trackChanges) =>
            await FindByCondition(t => t.Id.Equals(teacherId), trackChanges)
            .Include(s => s.Courses)
            .ThenInclude(c => c.Groups)
            .ThenInclude(g => g.Students)
            .SelectMany(s => s.Courses)
            .ToListAsync();

        public async Task<Teacher> GetTeacherAsync(Guid teacherId, bool trackChanges) =>
            await FindByCondition(t => t.Id.Equals(teacherId), trackChanges)
            .Include(t => t.Courses)
            .ThenInclude(c => c.Assignments)
            .SingleOrDefaultAsync();

        public async Task<Teacher> GetTeacherByBaseUserIdAsync(string userId, bool trackChanges) =>
            await FindByCondition(s => s.UserId.Equals(userId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
