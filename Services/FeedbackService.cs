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
    internal sealed class FeedbackService: IFeedbackService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public FeedbackService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<Feedback>> GetFeedbackAsync(Guid projectId, bool trackChanges)
        {
            var feedback = await _repository.Feedback.GetFeedbackAsync(projectId, trackChanges);

            return feedback;
        }
    }
}
