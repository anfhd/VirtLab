using Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtLab.Presentation.Controllers
{
    [Route("api/feedback")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IServiceManager _service;

        public FeedbackController(IServiceManager service) => _service = service;

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetFeedback(Guid id)
        {
            var feedback = await _service.FeedbackService.GetFeedbackAsync(id, trackChanges: false);

            return Ok(feedback);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeedbackForProject([FromBody] FeedbackForCreationDto feedback)
        {
            await _service.FeedbackService.CreateFeedbackForProjectAsync(feedback);

            return StatusCode(201);
        }
    }
}
