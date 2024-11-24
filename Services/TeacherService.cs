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
    internal sealed class TeacherService: ITeacherService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public TeacherService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public void CreateTeacher(Teacher teacher)
        {
            _repository.Teacher.CreateTeacher(teacher);
            _repository.Save();
        }

        public IEnumerable<Teacher> GetAllTeachers(bool trackChanges)
        {
            var teachers = _repository.Teacher.GetAllTeachers(trackChanges);

            return teachers;
        }

        public Teacher GetTeacher(int teacherId, bool trackChanges) => _repository.Teacher.GetTeacher(teacherId, trackChanges);
    }
}
