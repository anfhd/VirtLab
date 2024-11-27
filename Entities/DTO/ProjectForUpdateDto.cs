using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class ProjectForUpdateDto
    {
        public string Name { get; set; }
        public bool IsSentForReview { get; set; }
        public bool IsAccepted { get; set; }

        public ICollection<Guid>? TechnologyIds { get; set; }
        public ICollection<Guid>? ProgrammingLanguageIds { get; set; }
        public ICollection<Guid>? ParticipantIds { get; set; }
    }
}
