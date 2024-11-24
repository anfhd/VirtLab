using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Mark
    {
        public Guid Id { get; set; }
        public float Value { get; set; }

        [ForeignKey("Teacher")]
        public Guid TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
