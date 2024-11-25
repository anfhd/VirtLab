using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Assignment
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        [ForeignKey("Course")]
        public Guid CourseId { get; set; }
        public Course? Course { get; set; }
        public virtual ICollection<Project>? Projects { get; set; }
    }
}
