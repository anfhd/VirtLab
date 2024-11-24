using System;
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

        Task SaveAsync();
    }
}
