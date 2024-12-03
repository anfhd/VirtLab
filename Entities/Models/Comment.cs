using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("File")]
        public Guid FileId { get; set; }
        public virtual File? File { get; set; }

        [ForeignKey("Teacher")]
        public Guid TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}
