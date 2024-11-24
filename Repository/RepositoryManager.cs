using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager: IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ITechnologyRepository> _technologyRepository;
        private readonly Lazy<IProjectRepository> _projectRepository;
        private readonly Lazy<IStudentRepository> _studentRepository;
        private readonly Lazy<IProgrammingLanguageRepository> _programmingLanguageRepository;
        private readonly Lazy<ICourseRepository> _courseRepository;
        private readonly Lazy<IGroupRepository> _groupRepository;
        private readonly Lazy<ITeacherRepository> _teacherRepository;
        private readonly Lazy<IFeedbackRepository> _fedbackRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _programmingLanguageRepository = new Lazy<IProgrammingLanguageRepository>(() => 
                new ProgrammingLanguageRepository(repositoryContext));
            _projectRepository = new Lazy<IProjectRepository>(() =>
                new ProjectRepository(repositoryContext));
            _studentRepository =  new Lazy<IStudentRepository>(() =>
                new StudentRepository(repositoryContext));
            _technologyRepository = new Lazy<ITechnologyRepository>(() =>
                new TechnologyRepository(repositoryContext));
            _courseRepository = new Lazy<ICourseRepository>(() =>
                new CourseRepository(repositoryContext));
            _groupRepository = new Lazy<IGroupRepository>(() =>
                new GroupRepository(repositoryContext));
            _teacherRepository = new Lazy<ITeacherRepository>(() =>
                new TeacherRepository(repositoryContext));
            _fedbackRepository = new Lazy<IFeedbackRepository>(() =>
                new FeedbackRepository(repositoryContext));
        }

        public IProgrammingLanguageRepository ProgrammingLanguage => _programmingLanguageRepository.Value;
        public IProjectRepository Project => _projectRepository.Value;
        public IStudentRepository Student => _studentRepository.Value;
        public ITechnologyRepository Technology => _technologyRepository.Value;
        public ITeacherRepository Teacher => _teacherRepository.Value;
        public IGroupRepository Group => _groupRepository.Value;
        public ICourseRepository Course => _courseRepository.Value;
        public IFeedbackRepository Feedback => _fedbackRepository.Value;

        public void Save() => _repositoryContext.SaveChanges();
    }
}
