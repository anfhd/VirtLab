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
    public class MarkRepository : RepositoryBase<Mark>, IMarkRepository
    {
        public MarkRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateMarkForProjectAsync(Mark mark) => Create(mark);

        public async Task<Mark> GetMarkForProjectAsync(Guid projectId, bool trackChanges) =>
            await FindByCondition(m => m.ProjectId.Equals(projectId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
