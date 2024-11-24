using Contracts;
using Entities.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class ProgrammingLanguageService: IProgrammingLanguageService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public ProgrammingLanguageService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<ProgrammingLanguage>> GetAllProgrammingLanguagesAsync(bool trackChanges)
        {
            var programmingLanguages = await _repository.ProgrammingLanguage.GetAllProgrammingLanguagesAsync(trackChanges);

            return programmingLanguages;
        }
    }
}
