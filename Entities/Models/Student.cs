using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public virtual ICollection<Project>? Projects { get; set; }
    }
}
