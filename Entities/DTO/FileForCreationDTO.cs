using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class FileForCreationDTO
    {
        public string? Name { get; set; }
        public string? Extension { get; set; }
        public Guid ProjectId { get; set; }
        public string? Content { get; set; }
    }
}
