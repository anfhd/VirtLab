﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IProgrammingLanguageRepository ProgrammingLanguage { get; }
        IProjectRepository Project { get; }
        IStudentRepository Student { get; }
        ITechnologyRepository Technology { get; }
        ITeacherRepository Teacher { get; }
        IGroupRepository Group { get; }
        ICourseRepository Course { get; }
        IFeedbackRepository Feedback { get; }
        IMarkRepository Mark { get; }
        IFileRepository File { get; }
        IPermissionRepository Permission { get; }
        IFileVersionRepository FileVersion { get; }
        ICommentRepository Comment { get; }
        IInvitationRepository Invitation { get; }

        Task SaveAsync();
    }
}
