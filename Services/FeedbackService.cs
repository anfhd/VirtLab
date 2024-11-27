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
    internal sealed class FeedbackService: IFeedbackService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public FeedbackService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task CreateFeedbackForProjectAsync(Feedback feedback) => await _repository.Feedback.CreateFeedbackForProjectAsync(feedback);

        public async Task CreateFeedbackForProjectAsync(FeedbackForCreationDto feedback)
        {
            var feedbackEntity = _mapper.Map<Feedback>(feedback);

            await _repository.Feedback.CreateFeedbackForProjectAsync(feedbackEntity);

            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<Feedback>> GetFeedbackAsync(Guid projectId, bool trackChanges)
        {
            var feedback = await _repository.Feedback.GetFeedbackAsync(projectId, trackChanges);

            return feedback;
        }
    }
}
