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
       // public Student? Owner { get; set; }

        //public Guid MarkId { get; set; }
        //public Mark? Mark { get; set; }

        public Guid AssignmentId { get; set; }
        // public virtual Assignment? Assignment { get; set; }

        //public virtual ICollection<Technology>? Technologies { get; set; }
        //public virtual ICollection<ProgrammingLanguage>? ProgrammingLanguages { get; set; }
        //public virtual ICollection<Student>? Participants { get; set; }

        public ICollection<Guid>? TechnologyIds { get; set; }
        public ICollection<Guid>? ProgrammingLanguageIds { get; set; }
        public ICollection<Guid>? ParticipantIds { get; set; }
    }
}
