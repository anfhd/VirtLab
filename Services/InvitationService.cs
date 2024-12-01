using Contracts;
using Entities.DTO;
using Entities.Exceptions;
using Entities.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class InvitationService : IInvitationService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public InvitationService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task ChangeToAccepted(Guid invitationId, bool trackChanges)
        {
            var invitationEntity = await _repository.Invitation.GetInvitationAsync(invitationId, trackChanges);
            invitationEntity.IsAccepted = true;

            await _repository.SaveAsync();
        }

        public async Task<Guid> CreateInvitationAsync(InvitationForCreationDto invitation)
        {
            var id = Guid.NewGuid();

            var invitationEntity = new Invitation()
            {
                Id = id,
                ProjectId = invitation.ProjectId,
                Project = await _repository.Project.GetProjectAsync(invitation.ProjectId, true),
                StudentId = invitation.StudentId,
                Student = await _repository.Student.GetStudentAsync(invitation.StudentId, true),
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(2),
                IsAccepted = false
            };

            await _repository.Invitation.CreateInvitation(invitationEntity);
            await _repository.SaveAsync();

            return id;
        }

        public Task<string> CreateUrl(Invitation invitation)
        {
            return Task.FromResult($"https://localhost:5001/api/invitation/{invitation.Id}");
        }

        public async Task<Invitation> GetInvitationAsync(Guid invitationId, bool trackChanges)
        {
            var invite = await _repository.Invitation.GetInvitationAsync(invitationId, trackChanges);

            if (invite is null) throw new ProjectNotFoundException(invitationId); //todo

            return invite;
        }
    }
}
