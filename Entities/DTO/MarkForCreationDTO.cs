using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class MarkForCreationDTO
    {
        public float Value { get; set; }
        public Guid ProjectId { get; set; }
        public Guid TeacherId { get; set; }
    }
}
