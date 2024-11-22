using Contracts;
using Entities.Models;
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
    }
}
