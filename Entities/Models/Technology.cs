﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Technology
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Project>? Projects { get; set; }
    }
}
