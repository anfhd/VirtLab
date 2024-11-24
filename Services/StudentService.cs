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

        public IEnumerable<Student> GetAllStudents(bool trackChanges)
        {
            try
            {
                var students = _repository.Student.GetAllStudents(trackChanges);

                return students;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Somehting went wrong in the {nameof(GetAllStudents)} service method {ex}");

                throw;
            }
        }
    }
}
