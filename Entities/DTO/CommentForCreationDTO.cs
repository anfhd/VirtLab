using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class CommentForCreationDTO
    {  
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid FileId { get; set; }
        public Guid TeacherId { get; set; }
    }
}
