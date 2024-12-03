using Contracts;
using Entities.Models;
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
    }
}
