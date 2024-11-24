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
    public class TechnologyRepository: RepositoryBase<Technology>, ITechnologyRepository
    {
        public TechnologyRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
            
        }

        public async Task<IEnumerable<Technology>> GetAllTechnologiesAsync(bool trackChanges) =>
           await FindAll(trackChanges)
           .OrderBy(t => t.Name)
           .ToListAsync();
    }
}
