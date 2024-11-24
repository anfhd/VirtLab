﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges);
        Task<Student> GetStudentAsync(Guid studentId, bool trackChanges);
        void CreateStudent(Student student);
        Task<IEnumerable<Course>> GetCoursesForStudentAsync(Guid studentId, bool trackChanges);
    }
}
