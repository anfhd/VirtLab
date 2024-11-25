using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class GroupNotFoundException : NotFoundException
    {
        public GroupNotFoundException(Guid groupId) : base($"Group with id: {groupId} doesn't exist in database.")
        {
        }
    }
}
