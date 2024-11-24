using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetAllGroupsAsync(bool trackChanges);
    }
}
