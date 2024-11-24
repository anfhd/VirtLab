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
    public class FeedbackRepository: RepositoryBase<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            
        }

        public async Task<IEnumerable<Feedback>> GetFeedbackAsync(Guid projectId, bool trackChanges) =>
            await FindByCondition(f => f.ProjectId.Equals(projectId), trackChanges)
            .ToListAsync();
    }
}
