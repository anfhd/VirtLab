using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class FileVersionNotFoundException : NotFoundException
    {
        public FileVersionNotFoundException(Guid fileVersionId) : base($"File version with id: {fileVersionId} doesn't exist in database.")
        {
        }
    }
}
