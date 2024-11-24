using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Feedback
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey("Teacher")]
        public Guid TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
