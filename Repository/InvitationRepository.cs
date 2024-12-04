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
            .ThenInclude(p=>p.Assignment)
            .ThenInclude(a=>a.Course)
            .Include(x => x.Project)
            .ThenInclude(p=>p.Owner)
            .ThenInclude(o=>o.User)
            .Include(x => x.Student)
            .ThenInclude(s=>s.User)
            .SingleOrDefaultAsync();

        public async Task CreateInvitation(Invitation invitation) => Create(invitation);
    }
}
