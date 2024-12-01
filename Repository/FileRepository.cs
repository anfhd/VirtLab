using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using File = Entities.Models.File;
using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public class FileRepository : RepositoryBase<File>, IFileRepository
    {
        public FileRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateFileForProjectAsync(File file) => Create(file);

        public async Task DeleteFileForProjectAsync(File file) => Delete(file);

        public async Task<File> GetFileForProjectAsync(Guid fileId, bool trackChanges) =>
            await FindByCondition(f => f.Id.Equals(fileId), trackChanges)
            .Include(f => f.Versions)
            .Include(f => f.Comments)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<File>> GetFilesForProjectAsync(Guid projectId, bool trackChanges) =>
            await FindByCondition(f => f.ProjectId.Equals(projectId), trackChanges)
            .Include(f => f.Versions)
            .Include(f => f.Comments)
            .ToListAsync();

        public async Task UpdateFileAsync(File file) =>  Update(file);
    }
}
