using AutoMapper;
using Contracts;
using Entities.DTO;
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
    internal sealed class TeacherService: ITeacherService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public TeacherService(
            IRepositoryManager repository,
            ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task CreateTeacher(Teacher teacher)
        {
            _repository.Teacher.CreateTeacher(teacher);
            await _repository.SaveAsync();
        }

        public async Task CreateTeacher(UserForRegistrationDto user)
        {
            var teacher = _mapper.Map<Teacher>(user);

            _repository.Teacher.CreateTeacher(teacher);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<Project>> GetProjectsForTeacherAsync(Guid teacherId, bool trackChanges)
        {
            var teacher = await _repository.Teacher.GetTeacherAsync(teacherId, trackChanges);

            if (teacher is null) throw new TeacherNotFoundException(teacherId);

            var projects = await _repository.Teacher.GeProjectsForTeacherAsync(teacherId, trackChanges);

            return projects;
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync(bool trackChanges)
        {
            var teachers = await _repository.Teacher.GetAllTeachersAsync(trackChanges);

            return teachers;
        }

        public async Task<IEnumerable<Course>> GetCoursesForTeacherAsync(Guid teacherId, bool trackChanges)
        {
            var teacher = await _repository.Teacher.GetTeacherAsync(teacherId, trackChanges);

            if (teacher is null) throw new TeacherNotFoundException(teacherId);

            var teacherCourses = await _repository.Teacher.GetCoursesForTeacherAsync(teacherId, trackChanges);

            return teacherCourses;
        }

        public async Task<Teacher> GetTeacherAsync(Guid teacherId, bool trackChanges)
        {
            var teacher = await _repository.Teacher.GetTeacherAsync(teacherId, trackChanges);

            if(teacher is null) throw new TeacherNotFoundException(teacherId);

            return teacher;
        }

        public IEnumerable<Teacher> GetAllTeachers(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Teacher GetTeacher(int teacherId, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
