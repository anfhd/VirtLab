using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.ComponentModel;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

[Route("api/invitation")]
[ApiController]
public class InvitationController : ControllerBase
{
    private readonly IServiceManager _service;
    public InvitationController(IServiceManager service)
        => _service = service;

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> AddUserToProject(Guid id)
    {
        var invite = await _service.InvitationService.GetInvitationAsync(id, trackChanges: false);

        if (invite == null)
            return NotFound("Invite does not exist");

        if (invite.ExpiresAt <= DateTime.UtcNow)
            return BadRequest("Invite is expired"); //todo

        if (invite.IsAccepted)
            return BadRequest("Invite was accepted"); //todo
        //дістати з сервісу інвайт
        //інвайт існує
        //інвайт просрочений
        //інвайт прийнятий

        var project = await _service.ProjectService.GetProjectAsync(invite.ProjectId, trackChanges: false);

        if(project == null)
            return BadRequest("Project does not exist"); //todo
        //дістати потрібний проєкт
        //чи існує проєкт

        var student = await _service.StudentService.GetStudentAsync(invite.StudentId, trackChanges: false);

        if (student == null)
            return BadRequest("User does not exist"); //todo

        if (project.Participants.Contains(student))
            return BadRequest("User is already a participant"); //todo
        //дістати студента
        //чи існує студент
        //подивитися чи студента вже нема там

        var newParticipants = project.Participants.Select(x => x.Id).ToList().Append(student.Id);

        ProjectForUpdateDto projectForUpdate = new()
        {
            Name = project.Name,
            IsAccepted = project.IsAccepted,
            IsSentForReview = project.IsSentForReview,
            TechnologyIds = project.Technologies.Select(x => x.Id).ToList(),
            ProgrammingLanguageIds = project.ProgrammingLanguages.Select(x => x.Id).ToList(),
            ParticipantIds = newParticipants.ToList()
        };

        await _service.ProjectService.UpdateProjectAsync(project.Id, projectForUpdate, trackChanges: true);
        await _service.InvitationService.ChangeToAccepted(id, trackChanges: true);
        //todo redirect

        return Redirect("https://localhost:4012/");
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateInvitation([FromBody] InvitationForCreationDto invitation)
    {
        var id = await _service.InvitationService.CreateInvitationAsync(invitation);
        InvitationForSendingDto sendingInvite = new()
        {
            Id = id,
            ProjectId = invitation.ProjectId,
            StudentId = invitation.StudentId
        };

        await _service.InvitationService.SendInvitationAsync(sendingInvite, trackChanges: false);

        return Ok();
    }
}