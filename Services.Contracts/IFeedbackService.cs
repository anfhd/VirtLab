using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IFeedbackService
    {
        IEnumerable<Feedback> GetFeedback(Guid projectId, bool trackChanges);
    }
}
