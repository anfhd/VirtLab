using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey("Group")]
        public Guid GroupId { get; set; }
        public virtual Group? Group { get; set; }
        // Проєкти, якими студент володіє
        public virtual ICollection<Project>? OwnedProjects { get; set; }
        // Проєкти, в яких студент бере участь
        public virtual ICollection<Project>? ParticipatedProjects { get; set; }
        public virtual ICollection<Course>? Courses { get; set; }
    }
}
