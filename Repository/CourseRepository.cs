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
    public class CourseRepository: RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();

        public async Task<Course> GetCourse(Guid courseId, bool trackChanges) =>
             await FindByCondition(c => c.Id.Equals(courseId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Assignment>> GetCourseAssignments(Guid courseId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(courseId), trackChanges)
            .Include(c => c.Assignments)
            .SelectMany(c => c.Assignments)
            .ToListAsync();
    }
}
