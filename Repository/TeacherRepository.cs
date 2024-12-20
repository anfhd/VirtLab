﻿using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TeacherRepository: RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public async Task CreateTeacherAsync(Teacher teacher) => Create(teacher);

        public async Task<IEnumerable<Project>> GeProjectsForTeacherAsync(Guid teacherId, bool trackChanges) =>
            await FindByCondition(t => t.Id.Equals(teacherId), trackChanges)
            .Include(t => t.Courses)
            .ThenInclude(c => c.Assignments)
            .ThenInclude(a => a.Projects)
            .ThenInclude(p => p.Technologies)
            .Include(t => t.Courses)
            .ThenInclude(c => c.Assignments)
            .ThenInclude(a => a.Projects)
            .ThenInclude(p => p.ProgrammingLanguages)
            .Include(t => t.Courses)
            .ThenInclude(c => c.Assignments)
            .ThenInclude(a => a.Projects)
            .ThenInclude(p => p.Owner)
            .ThenInclude(o=>o.User)
            .Include(t => t.Courses)
            .ThenInclude(c => c.Assignments)
            .ThenInclude(a => a.Projects)
            .ThenInclude(p => p.Participants)
            .ThenInclude(par=>par.User)
            .Include(t => t.Courses)
            .ThenInclude(c => c.Assignments)
            .ThenInclude(a => a.Projects)
            .ThenInclude(p => p.Assignment)
            .ThenInclude(a=>a.Course)
            .Include(t => t.Courses)
            .ThenInclude(c => c.Assignments)
            .ThenInclude(a => a.Projects)
            .ThenInclude(p => p.Owner)
            .ThenInclude(o=>o.Group)
            .Include(t => t.Courses)
            .ThenInclude(c => c.Assignments)
            .ThenInclude(a => a.Projects)
            .ThenInclude(p=>p.Mark)
            .Include(t => t.Courses)
            .ThenInclude(c => c.Assignments)
            .ThenInclude(a => a.Projects)
            .ThenInclude(p => p.Feedbacks)
            .SelectMany(t => t.Courses)
            .SelectMany(c => c.Assignments)
            .SelectMany(a => a.Projects)
            .ToListAsync();

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .Include(s => s.User)
            .ToListAsync();

        public async Task<IEnumerable<Course>> GetCoursesForTeacherAsync(Guid teacherId, bool trackChanges) =>
            await FindByCondition(t => t.Id.Equals(teacherId), trackChanges)
            .Include(s => s.Courses)
            .ThenInclude(c => c.Groups)
            .ThenInclude(g => g.Students)
            .SelectMany(s => s.Courses)
            .ToListAsync();

        public async Task<Teacher> GetTeacherAsync(Guid teacherId, bool trackChanges) =>
            await FindByCondition(t => t.Id.Equals(teacherId), trackChanges)
            .Include(t => t.User)
            .Include(t => t.Courses)
            .ThenInclude(c => c.Assignments)
            .ThenInclude(a=>a.Deadline)
            .Include(s => s.User)
            .SingleOrDefaultAsync();

        public async Task<Teacher> GetTeacherByBaseUserIdAsync(string userId, bool trackChanges) =>
            await FindByCondition(s => s.UserId.Equals(userId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
