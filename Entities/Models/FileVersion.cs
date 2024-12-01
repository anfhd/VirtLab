using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class FileVersion
    {
        public Guid Id { get; set; }
        public string? Content { get; set; } 

        [ForeignKey("File")]
        public Guid FileId { get; set; }
        public virtual File? File { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
