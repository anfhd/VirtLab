using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }
        public virtual ICollection<Course>? Courses { get; set; }
    }
}
