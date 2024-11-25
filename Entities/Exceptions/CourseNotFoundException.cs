using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CourseNotFoundException : NotFoundException
    {
        public CourseNotFoundException(Guid courseId) : base($"Course with id: {courseId} doesn't exist in database.")
        {
        }
    }
}
