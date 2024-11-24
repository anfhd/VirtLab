using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Course>? Courses { get; set; }
        public virtual ICollection<Student>? Students { get; set; }
    }
}
