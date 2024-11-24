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

        public IEnumerable<Feedback> GetFeedback(Guid projectId, bool trackChanges)
        {
            var feedback = _repository.Feedback.GetFeedback(projectId, trackChanges);

            return feedback;
        }
    }
}
