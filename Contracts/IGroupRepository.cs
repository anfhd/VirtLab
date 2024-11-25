using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetAllGroupsAsync(bool trackChanges);
        Task<IEnumerable<Course>> GetGroupCoursesAsync(Guid groupId, bool trackChanges);
        Task<Group> GetGroupAsync(Guid groupId, bool trackChanges);
    }
}
