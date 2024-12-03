using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IInvitationService
    {
        Task<Invitation> GetInvitationAsync(Guid invitationId, bool trackChanges);
        Task<Guid> CreateInvitationAsync(InvitationForCreationDto invitation);
        Task<string> CreateUrl(Invitation invitation);
        Task ChangeToAccepted(Guid invitationId, bool trackChanges);
        Task SendInvitationAsync(InvitationForSendingDto invitation, bool trackChanges);

        string InvitationBody { get; set; }
    }
}