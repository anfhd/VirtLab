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
    public class GroupRepository: RepositoryBase<Group>, IGroupRepository
    {
        public GroupRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            
        }

        public async Task<IEnumerable<Group>> GetAllGroupsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(g => g.Name)
            .ToListAsync();

        public async Task<Group> GetGroupAsync(Guid groupId, bool trackChanges) =>
             await FindByCondition(g => g.Id.Equals(groupId), trackChanges)
            .Include(g => g.Students)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Course>> GetGroupCoursesAsync(Guid groupId, bool trackChanges) =>
            await FindByCondition(g => g.Id.Equals(groupId), trackChanges)
            .Include(g => g.Courses)
            .SelectMany(g => g.Courses)
            .ToListAsync();
    }
}
