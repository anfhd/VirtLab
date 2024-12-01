using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class UserPermission
    {
        public Guid Id { get; set; }
        public bool CanView { get; set; }
        public bool CanEdit { get; set; }

        [ForeignKey("Student")]
        public Guid StudentId { get; set; }
        public virtual Student? Student { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public virtual Project? Project { get; set; }
    }
}
