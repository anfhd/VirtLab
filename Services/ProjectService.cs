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
    internal sealed class ProjectService: IProjectService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public ProjectService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<Project> GetAllProjects(bool trackChanges)
        {
            try
            {
                var projects = _repository.Project.GetAllProjects(trackChanges);

                return projects;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Somehting went wrong in the {nameof(GetAllProjects)} service method {ex}");

                throw;
            }
        }
    }
}
