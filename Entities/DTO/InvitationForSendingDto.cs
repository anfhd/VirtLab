using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class InvitationForSendingDto
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid ProjectId { get; set; }
    }
}
