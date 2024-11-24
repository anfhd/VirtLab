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
    public class GroupRepository: RepositoryBase<Group>, IGroupRepository
    {
        public GroupRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            
        }

        public async Task<IEnumerable<Group>> GetAllGroupsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(g => g.Name)
            .ToListAsync();
    }
}
