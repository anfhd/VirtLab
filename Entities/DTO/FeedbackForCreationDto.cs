using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class FeedbackForCreationDto
    {
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid TeacherId { get; set; }
        public Guid ProjectId { get; set; }
    }
}
