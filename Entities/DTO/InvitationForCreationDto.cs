using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class InvitationForCreationDto
    {
        public Guid StudentId { get; set; }
        public Guid ProjectId { get; set; }
    }
}
