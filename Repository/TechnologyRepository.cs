using Contracts;
using Entities.Models;
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

        public IEnumerable<Technology> GetAllTechnologies(bool trackChanges) =>
           FindAll(trackChanges)
           .OrderBy(t => t.Name)
           .ToList();
    }
}
