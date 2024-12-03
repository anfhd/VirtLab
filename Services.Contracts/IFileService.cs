using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTO;
using Entities.Models;
using File = Entities.Models.File;


namespace Services.Contracts
{
    public interface IFileService
    {
        Task CreateFileForProjectAsync(Guid projectId, FileForCreationDTO file);
        Task DeleteFileForProjectAsync(Guid fileId);
        Task<File> GetFileForProjectAsync(Guid projectId, Guid fileId, bool trackChanges);
        Task<IEnumerable<File>> GetFilesForProjectAsync(Guid projectId, bool trackChanges);
        Task UpdateFileAsync(Guid projectId, Guid fileId, FileForUpdateDto file);
        Task RestoreFileVersionAsync(Guid projectId, Guid fileId, Guid fileVersionId);
        Task DeleteFileVersionAsync(Guid projectId, Guid fileId, Guid fileVersionId);
        Task CreateCommentForFileAsync(Guid projectId, Guid fileId, CommentForCreationDTO comment);
        Task DeleteCommentForFileAsync(Guid projectId, Guid fileId, Guid commentId);
        Task UpdateCommentForFileAsync(Guid projectId, Guid fileId, Guid commentId, CommentForUpdateDTO comment);
        Task<IEnumerable<Comment>> GetAllCommentsForFileAsync(Guid projectId, Guid fileId, bool trackChanges);
        Task<FileVersion> GetVersionAsync(Guid versionId, bool trackChanges);
    }
}
