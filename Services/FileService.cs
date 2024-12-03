using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Entities.Models.File;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Exceptions;
using Entities.Models;
using System.ComponentModel.Design;

namespace Services
{
    internal sealed class FileService: IFileService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public FileService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task CreateCommentForFileAsync(Guid projectId, Guid fileId, CommentForCreationDTO comment)
        {
            var projectEntity = await _repository.Project.GetProjectAsync(projectId, false);

            if (projectEntity is null) throw new ProjectNotFoundException(projectId);

            var fileEntity = await _repository.File.GetFileForProjectAsync(fileId, false);

            if (fileEntity is null) throw new Entities.Exceptions.FileNotFoundException(fileId);

            var commentEntity = _mapper.Map<Comment>(comment);

            await _repository.Comment.CreateCommentAsync(commentEntity);

            await _repository.SaveAsync();
        }

        public async Task CreateFileForProjectAsync(Guid projectId, FileForCreationDTO file)
        {
            var projectEntity = await _repository.Project.GetProjectAsync(projectId, true);

            if (projectEntity is null) throw new ProjectNotFoundException(projectId);

            var fileEntity = _mapper.Map<File>(file);

            //fileEntity.Project = projectEntity;
            fileEntity.Versions = new List<FileVersion>();
            fileEntity.Versions.Add(new FileVersion()
            {
                Id = Guid.NewGuid(),
                Content = file.Content,
                FileId = fileEntity.Id
            });

            await _repository.File.CreateFileForProjectAsync(fileEntity);
            await _repository.SaveAsync();
        }

        public async Task DeleteCommentForFileAsync(Guid projectId, Guid fileId, Guid commentId)
        {
            var projectEntity = await _repository.Project.GetProjectAsync(projectId, false);

            if (projectEntity is null) throw new ProjectNotFoundException(projectId);

            var fileEntity = await _repository.File.GetFileForProjectAsync(fileId, false);

            if (fileEntity is null) throw new Entities.Exceptions.FileNotFoundException(fileId);

            var commentEntity = await _repository.Comment.GetCommentAsync(commentId, true);

            if(commentEntity is null) throw new CommentNotFoundException(commentId);

            await _repository.Comment.DeleteCommentAsync(commentEntity);

            await _repository.SaveAsync();
        }

        public async Task DeleteFileForProjectAsync(Guid fileId)
        {
            var fileEntity = await _repository.File.GetFileForProjectAsync(fileId, false);

            if (fileEntity is null) throw new Entities.Exceptions.FileNotFoundException(fileId);

            await _repository.File.DeleteFileForProjectAsync(fileEntity);

            await _repository.SaveAsync();
        }

        public async Task DeleteFileVersionAsync(Guid projectId, Guid fileId, Guid fileVersionId)
        {
            var projectEntity = await _repository.Project.GetProjectAsync(projectId, false);

            if (projectEntity is null) throw new ProjectNotFoundException(projectId);

            var fileEntity = await _repository.File.GetFileForProjectAsync(fileId, false);

            if (fileEntity is null) throw new Entities.Exceptions.FileNotFoundException(fileId);

            var fileVersion = fileEntity.Versions.SingleOrDefault(fv => fv.Id == fileVersionId);

            if (fileVersion is null) throw new FileVersionNotFoundException(fileVersionId);

            await _repository.FileVersion.DeleteFileVersionAsync(fileVersion);

            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsForFileAsync(Guid projectId, Guid fileId, bool trackChanges)
        {
            var projectEntity = await _repository.Project.GetProjectAsync(projectId, false);

            if (projectEntity is null) throw new ProjectNotFoundException(projectId);

            var fileEntity = await _repository.File.GetFileForProjectAsync(fileId, false);

            if (fileEntity is null) throw new Entities.Exceptions.FileNotFoundException(fileId);

            var comments = await _repository.Comment.GetAllCommentsForFileAsync(fileId, trackChanges);

            return comments;
        }

        public async Task<File> GetFileForProjectAsync(Guid projectId, Guid fileId, bool trackChanges)
        {
            var fileEntity = await _repository.File.GetFileForProjectAsync(fileId, false);

            if (fileEntity is null) throw new Entities.Exceptions.FileNotFoundException(fileId);

            return fileEntity;
        }


        public async Task<IEnumerable<File>> GetFilesForProjectAsync(Guid projectId, bool trackChanges)
        {
            var projectEntity = await _repository.Project.GetProjectAsync(projectId, false);

            if (projectEntity is null) throw new ProjectNotFoundException(projectId);

            var projectFiles = await _repository.File.GetFilesForProjectAsync(projectId, trackChanges);

            return projectFiles;
        }

        public async Task RestoreFileVersionAsync(Guid projectId, Guid fileId, Guid fileVersionId)
        {
            var projectEntity = await _repository.Project.GetProjectAsync(projectId, false);

            if (projectEntity is null) throw new ProjectNotFoundException(projectId);

            var fileEntity = await _repository.File.GetFileForProjectAsync(fileId, false);

            if (fileEntity is null) throw new Entities.Exceptions.FileNotFoundException(fileId);

            var fileVersion = fileEntity.Versions.SingleOrDefault(fv => fv.Id == fileVersionId);

            if(fileVersion is null) throw new FileVersionNotFoundException(fileVersionId);

            await _repository.FileVersion.CreateFileVersionAsync(new FileVersion()
            {
                Content = fileVersion.Content,
                Id = Guid.NewGuid(),
                FileId = fileId
            });

            await _repository.SaveAsync();
        }

        public async Task UpdateCommentForFileAsync(Guid projectId, Guid fileId, Guid commentId, CommentForUpdateDTO comment)
        {
            var projectEntity = await _repository.Project.GetProjectAsync(projectId, false);

            if (projectEntity is null) throw new ProjectNotFoundException(projectId);

            var fileEntity = await _repository.File.GetFileForProjectAsync(fileId, false);

            if (fileEntity is null) throw new Entities.Exceptions.FileNotFoundException(fileId);

            var commentEntity = await _repository.Comment.GetCommentAsync(commentId, true);

            if (commentEntity is null) throw new CommentNotFoundException(commentId);

            commentEntity.Content = comment.Content;

            await _repository.SaveAsync();
        }

        public async Task UpdateFileAsync(Guid projectId, Guid fileId, FileForUpdateDto file)
        {
            var projectEntity = await _repository.Project.GetProjectAsync(projectId, false);

            if (projectEntity is null) throw new ProjectNotFoundException(projectId);

            var fileEntity = await _repository.File.GetFileForProjectAsync(fileId, false);

            if (fileEntity is null) throw new Entities.Exceptions.FileNotFoundException(fileId);

            await _repository.FileVersion.CreateFileVersionAsync(new FileVersion()
            {
                Content = file.Content,
                Id = Guid.NewGuid(),
                FileId = fileEntity.Id
            });

            await _repository.SaveAsync();
        }

        public async Task<FileVersion> GetVersionAsync(Guid versionId, bool trackChanges)
        {
            var version = await _repository.FileVersion.GetVersionAsync(versionId, trackChanges);

            if (version is null) throw new FileVersionNotFoundException(versionId);

            return version;
        }

    }
}
