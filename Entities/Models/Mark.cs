
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities.Models
{
    public class Mark
    {
        public Guid Id { get; set; }
        public float Value { get; set; }
        public Guid ProjectId { get; set; }
        public virtual Project? Project { get; set; }
        public Guid TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}
