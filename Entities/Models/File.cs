using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class File
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } 
        public string? Extension { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public virtual Project? Project { get; set; }

        public virtual ICollection<FileVersion>? Versions { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
