using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsSentForReview { get; set; }
        public bool IsAccepted {  get; set; }

        [ForeignKey("Owner")]
        public Guid OwnerId { get; set; }
        public Student? Owner { get; set; }
    }
}
