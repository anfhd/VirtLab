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
    public class ProgrammingLanguageRepository: RepositoryBase<ProgrammingLanguage>, IProgrammingLanguageRepository
    {
        public ProgrammingLanguageRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<ProgrammingLanguage>> GetAllProgrammingLanguagesAsync(bool trackChanges) => 
            await FindAll(trackChanges)
            .OrderBy(pl => pl.Name)
            .ToListAsync();
    }
}
