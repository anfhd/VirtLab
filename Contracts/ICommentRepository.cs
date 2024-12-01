using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICommentRepository
    {
        Task CreateCommentAsync(Comment comment);
        Task DeleteCommentAsync(Comment comment);
        Task<IEnumerable<Comment>> GetAllCommentsForFileAsync(Guid fileId, bool trackChanges);
        Task<Comment> GetCommentAsync(Guid commentId, bool trackChanges);
    }
}
