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

        public IEnumerable<Technology> GetAllTechnologies(bool trackChanges)
        {
            try
            {
                var technologies = _repository.Technology.GetAllTechnologies(trackChanges);

                return technologies;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Somehting went wrong in the {nameof(GetAllTechnologies)} service method {ex}");

                throw;
            }
        }
    }
}
