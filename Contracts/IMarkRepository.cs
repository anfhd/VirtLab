using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMarkRepository
    {
        Task CreateMarkForProjectAsync(Mark mark);
        Task<Mark> GetMarkForProjectAsync(Guid projectId, bool trackChanges);
    }
}
