using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class MarkService: IMarkService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public MarkService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateMarkForProjectAsync(MarkForCreationDTO mark)
        {
            var markEntity = _mapper.Map<Mark>(mark);

            await _repository.Mark.CreateMarkForProjectAsync(markEntity);

            await _repository.SaveAsync();
        }

        public async Task<Mark> GetMarkForProjectAsync(Guid projectId, bool trackChanges) => await _repository.Mark.GetMarkForProjectAsync(projectId, trackChanges);
    }
}
