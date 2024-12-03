using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FileVersionRepository : RepositoryBase<FileVersion>, IFileVersionRepository
    {
        public FileVersionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateFileVersionAsync(FileVersion version) => Create(version);

        public async Task DeleteFileVersionAsync(FileVersion version) => Delete(version);

        public async Task<FileVersion> GetVersionAsync(Guid versionId, bool trackChanges) =>
             await FindByCondition(v => v.Id.Equals(versionId), trackChanges)
            .Include(v=>v.File)
            .ThenInclude(f=>f.Comments)
            .ThenInclude(c=>c.Teacher)
            .ThenInclude(t=>t.User)
            .SingleOrDefaultAsync();
    }
}
