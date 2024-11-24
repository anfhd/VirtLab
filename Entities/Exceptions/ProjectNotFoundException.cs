using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class ProjectNotFoundException : NotFoundException
    {
        public ProjectNotFoundException(Guid projectId) : base($"Project with id: {projectId} doesn't exist in database.")
        {
        }
    }
}
