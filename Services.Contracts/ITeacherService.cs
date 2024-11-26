﻿using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllTeachersAsync(bool trackChanges);
        Task<Teacher> GetTeacherAsync(Guid teacherId, bool trackChanges);
        Task CreateTeacher(Teacher teacher);
        Task CreateTeacher(UserForRegistrationDto user);
        Task<IEnumerable<Course>> GetCoursesForTeacherAsync(Guid teacherId, bool trackChanges);
        Task<IEnumerable<Project>> GetProjectsForTeacherAsync(Guid teacherId, bool trackChanges);
    }
}
