using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using File= Entities.Models.File;

namespace Contracts
{
    public interface IFileRepository
    {
        Task CreateFileForProjectAsync(File file);
        Task DeleteFileForProjectAsync(File file);
        Task<File> GetFileForProjectAsync(Guid fileId, bool trackChanges);
        Task<IEnumerable<File>> GetFilesForProjectAsync(Guid projectId, bool trackChanges);
        Task UpdateFileAsync(File file);
    }
}
