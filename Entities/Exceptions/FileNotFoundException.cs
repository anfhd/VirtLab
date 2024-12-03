﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class FileNotFoundException : NotFoundException
    {
        public FileNotFoundException(Guid fileId) : base($"File with id: {fileId} doesn't exist in database.") 
        { 
        }
    }
}
