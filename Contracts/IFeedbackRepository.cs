using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetFeedbackAsync(Guid projectId, bool trackChanges);
    }
}
