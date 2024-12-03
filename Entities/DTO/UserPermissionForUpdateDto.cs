using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class UserPermissionForUpdateDto
    {
        public bool CanView { get; set; }
        public bool CanEdit { get; set; }
        public Guid StudentId { get; set; }
    }
}
