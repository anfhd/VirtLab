using Contracts;
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

        public void CreateStudent(Student student)
        {
            _repository.Student.CreateStudent(student);
            _repository.Save();
        }

        public IEnumerable<Student> GetAllStudents(bool trackChanges)
        {
            var students = _repository.Student.GetAllStudents(trackChanges);

            return students;
        }

        public Student GetStudent(Guid studentId, bool trackChanges) => _repository.Student.GetStudent(studentId, trackChanges);
    }
}
