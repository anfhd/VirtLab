using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class ProjectForCreationDto
    {
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public Guid AssignmentId { get; set; }


        public ICollection<Guid>? TechnologyIds { get; set; }
        public ICollection<Guid>? ProgrammingLanguageIds { get; set; }
        public ICollection<Guid>? ParticipantIds { get; set; }
    }
}
