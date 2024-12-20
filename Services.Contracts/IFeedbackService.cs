﻿using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IFeedbackService
    {
        Task<IEnumerable<Feedback>> GetFeedbackAsync(Guid projectId, bool trackChanges);
        Task CreateFeedbackForProjectAsync(FeedbackForCreationDto feedback);
    }
}
