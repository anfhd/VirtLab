﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsSentForReview { get; set; }
        public bool IsAccepted {  get; set; }
        public bool IsDeleted { get; set; }

        public Guid OwnerId { get; set; }
        public Student? Owner { get; set; }

        public Guid AssignmentId { get; set; }
        public virtual Assignment? Assignment { get; set; }

      

        public virtual ICollection<Feedback>? Feedbacks { get; set; }
        public virtual ICollection<Technology>? Technologies { get; set; }
        public virtual ICollection<ProgrammingLanguage>? ProgrammingLanguages { get; set; }
        public virtual ICollection<Student>? Participants { get; set; }
        public virtual ICollection<File>? Files { get; set; }
        public virtual ICollection<UserPermission>? Permissions { get; set; }
        public virtual Mark? Mark { get; set; }
    }
}
