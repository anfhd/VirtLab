using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IMarkService
    {
        Task CreateMarkForProjectAsync(MarkForCreationDTO mark);
        Task<Mark> GetMarkForProjectAsync(Guid projectId, bool trackChanges);
    }
}
