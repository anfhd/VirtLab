using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IProgrammingLanguageService ProgrammingLanguageService { get; }
        IProjectService ProjectService { get; }
        IStudentService StudentService { get; }
        ITechnologyService TechnologyService { get; }
        IGroupService GroupService { get; }
        ITeacherService TeacherService { get; }
        ICourseService CourseService { get; }
        IFeedbackService FeedbackService { get; }
    }
}
