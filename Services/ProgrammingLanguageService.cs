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

        public IEnumerable<ProgrammingLanguage> GetAllProgrammingLanguages(bool trackChanges)
        {
            try
            {
                var programmingLanguages = _repository.ProgrammingLanguage.GetAllProgrammingLanguages(trackChanges);

                return programmingLanguages;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Somehting went wrong in the {nameof(GetAllProgrammingLanguages)} service method {ex}");

                throw;
            }
        }
    }
}
