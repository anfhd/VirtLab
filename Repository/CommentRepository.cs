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
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateCommentAsync(Comment comment) => Create(comment);

        public async Task DeleteCommentAsync(Comment comment) => Delete(comment);

        public async Task<IEnumerable<Comment>> GetAllCommentsForFileAsync(Guid fileId, bool trackChanges) =>
            await FindByCondition(c => c.FileId.Equals(fileId), trackChanges)
            .ToListAsync();

        public async Task<Comment> GetCommentAsync(Guid commentId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(commentId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
