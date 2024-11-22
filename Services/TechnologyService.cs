using Contracts;
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
    }
}
