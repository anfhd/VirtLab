using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FeedbackRepository: RepositoryBase<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            
        }

        public IEnumerable<Feedback> GetFeedback(Guid projectId, bool trackChanges) =>
            FindByCondition(f => f.ProjectId.Equals(projectId), trackChanges)
            .ToList();
    }
}
