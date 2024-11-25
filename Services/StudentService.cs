using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class StudentService: IStudentService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public StudentService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async void CreateStudent(Student student)
        {
            _repository.Student.CreateStudent(student);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<Project>> GetAllStudentProjectsAsync(Guid studentId, bool trackChanges)
        {
            var student = await _repository.Student.GetStudentAsync(studentId, trackChanges);

            if (student is null) throw new StudentNotFoundException(studentId);

            var ownedProjects = await _repository.Student.GetStudentOwnedProjectsAsync(studentId, trackChanges);
            var participatedProjects = await _repository.Student.GetStudentParticipatedProjectsAsync(studentId, trackChanges);

            return ownedProjects.Concat(participatedProjects).Distinct();
        }
        public async Task<IEnumerable<Project>> GetOwnedStudentProjectsAsync(Guid studentId, bool trackChanges)
        {
            var student = await _repository.Student.GetStudentAsync(studentId, trackChanges);

            if (student is null) throw new StudentNotFoundException(studentId);

            var ownedProjects = await _repository.Student.GetStudentOwnedProjectsAsync(studentId, trackChanges);
            
            return ownedProjects;
        }
        public async Task<IEnumerable<Project>> GetParticipatedStudentProjectsAsync(Guid studentId, bool trackChanges)
        {
            var student = await _repository.Student.GetStudentAsync(studentId, trackChanges);

            if (student is null) throw new StudentNotFoundException(studentId);

            var participatedProjects = await _repository.Student.GetStudentParticipatedProjectsAsync(studentId, trackChanges);

            return participatedProjects;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges)
        {
            var students = await _repository.Student.GetAllStudentsAsync(trackChanges);

            return students;
        }

        public async Task<IEnumerable<Course>> GetCoursesForStudentAsync(Guid studentId, bool trackChanges)
        {
            var student = await _repository.Student.GetStudentAsync(studentId, trackChanges);

            if (student is null) throw new StudentNotFoundException(studentId);

            var studentCourses = await _repository.Student.GetCoursesForStudentAsync(studentId, trackChanges);

            return studentCourses;
        }

        public async Task<Student> GetStudentAsync(Guid studentId, bool trackChanges)
        {
            var student = await _repository.Student.GetStudentAsync(studentId, trackChanges);

            if(student is null) throw new StudentNotFoundException(studentId);

            return student;
        }

        public async Task<IEnumerable<Assignment>> GetStudentAssignmentsAsync(Guid studentId, bool trackChanges)
        {
            var student = await _repository.Student.GetStudentAsync(studentId, trackChanges);

            if (student is null) throw new StudentNotFoundException(studentId);

            var studentAssignments = await _repository.Student.GetStudentAssignmentsAsync(studentId, trackChanges);

            return studentAssignments;
        }
    }
}
