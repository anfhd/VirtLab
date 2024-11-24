using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Course
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("Teacher")]
        public Guid TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        public virtual ICollection<Student>? Students { get; set; }

    }
}
