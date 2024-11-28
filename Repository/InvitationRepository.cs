using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class InvitationRepository : RepositoryBase<Invitation>, IInvitationRepository
    {
        public InvitationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
        public async Task<Invitation> GetInvitationAsync(Guid invitationId, bool trackChanges) =>
           await FindByCondition(p => p.Id.Equals(invitationId), trackChanges)
            .Include(x => x.Project)
            .Include(x => x.Student)
            .SingleOrDefaultAsync();

        public async Task CreateInvitation(Invitation invitation) => Create(invitation);
    }
}
