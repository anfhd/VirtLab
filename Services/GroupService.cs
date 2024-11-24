﻿using Contracts;
using Entities.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class GroupService : IGroupService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public GroupService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<Group>> GetAllGroupsAsync(bool trackChanges)
        {
            var groups = await _repository.Group.GetAllGroupsAsync(trackChanges);

            return groups;
        }
    }
}
