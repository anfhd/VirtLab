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

        public void CreateTeacher(Teacher teacher) => Create(teacher);

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .ToListAsync();

        public async Task<IEnumerable<Course>> GetCoursesForTeacherAsync(Guid teacherId, bool trackChanges) =>
            await FindByCondition(t => t.Id.Equals(teacherId), trackChanges)
            .Include(s => s.Courses)
            .SelectMany(s => s.Courses)
            .ToListAsync();

        public async Task<Teacher> GetTeacherAsync(Guid teacherId, bool trackChanges) =>
            await FindByCondition(t => t.Id.Equals(teacherId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
