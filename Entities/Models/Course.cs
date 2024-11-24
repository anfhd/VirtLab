using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Course
    {
        public Guid Id { get; set; }

        [ForeignKey("Teacher")]
        public Guid TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
