using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IInvitationRepository
    {
        Task<Invitation> GetInvitationAsync(Guid invitationId, bool trackChanges);
        Task CreateInvitation(Invitation invitation);
    }
}
