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
    internal sealed class TechnologyService: ITechnologyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public TechnologyService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<Technology>> GetAllTechnologiesAsync(bool trackChanges)
        {
            var technologies = await _repository.Technology.GetAllTechnologiesAsync(trackChanges);

            return technologies;
        }
    }
}
