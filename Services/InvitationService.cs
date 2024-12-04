using Contracts;
using Entities.DTO;
using Entities.Exceptions;
using Entities.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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

        public async Task SendInvitationAsync(InvitationForSendingDto invitation, bool trackChanges)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("virtlab.noreply@gmail.com", "arua hgtt ixgh gepl"),
                EnableSsl = true
            };

            var project = await _repository.Project.GetProjectAsync(invitation.ProjectId, trackChanges: false);
            var student = await _repository.Student.GetStudentAsync(invitation.StudentId, trackChanges: false);
            var owner = project.Owner;

            var person = owner.User.UserName;
            var email = student.User.Email;
            var projectName = project.Name;
            var link = $"http://localhost:4200/invite?id={invitation.Id}";

            var message = InvitationBody.Replace("{link}", link).Replace("{projectName}", projectName).Replace("{person}", person).Replace("{email}", email);

            var mailMessage = new MailMessage
            {
                From = new MailAddress("virtlab.noreply@gmail.com"),
                Subject = $"[ VirtLab ]: Invitation to {projectName} project",
                Body = message,
                IsBodyHtml = true
            };

            mailMessage.To.Add(email);

            client.Send(mailMessage);
        }

        public string InvitationBody
        {
            get => @"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>HTML Page Template</title>
    <style>
        /* Загальні стилі */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f9;
            color: #333;
        }

        header {
            background-color: #4e9caf85;
            color: white;
            padding: 1rem 2rem;
            text-align: center;
        }

        main {
            padding: 2rem;
        }

        div {
            text-align: center;
        }

        footer {
            background-color: #333;
            color: white;
            text-align: center;
            position: fixed;
            bottom: 0;
            width: 100%;
        }

        .a-inv {
            background-color: #4892a2; /* Колір кнопки */
            color: white !important; /* Колір тексту */
            text-decoration: none !important;
            border: none; /* Без рамки */
            padding: 0.75rem 1.5rem; /* Відступи */
            border-radius: 8px; /* Заокруглені кути */
            font-size: 1rem; /* Розмір шрифту */
            cursor: pointer; /* Вказівник миші при наведенні */
            margin-top: 1rem; /* Відступ зверху */
            transition: background-color 0.3s; /* Анімація при наведенні */
        }

        .main-text {
            font-size: 1.5rem;
        }

        .alter-text {
            opacity: 0.7;
            font-size: 0.8rem;
            margin: 0;
            margin-top: 1rem;
        }

        a {
            font-size: 0.8rem;
        }
    </style>
     <script>
        function redirectToPage(link) {
            window.location.href = link; // Заміни на свою URL
        }
    </script>
</head>
<body>
    <header>
        <h1>VirtLab</h1>
    </header>
    <main>
        <div>
            <p class=""main-text"">{person} has invited you to collaborate on the <b>{projectName}</b> project</p>
            <hr>
            <p>You can accept or decline this invitation.</p>
            <p>This invitation will expire in 7 days.</p>
            <br />
            <a class=""a-inv"" href=""{link}"" target=""_blank"">View invitation</a>
            <br />
            <br />
        </div>
            <p><b>Note:</b> This invitation was intended for <b>{email}</b>. If you were not expecting this invitation, you can ignore this email.</p>
            <hr>
            <p class=""alter-text""><b>Button not working?</b> Copy and paste this link into your browser:</p>
            <a href=""{link}"" target=""_blank"">{link}</a>
        
    </main>
    <footer>
        <p>&copy; 2024 Semicolon Software. All rights reserved.</p>
    </footer>
</body>
</html>
";
            set => Console.WriteLine(":D");
        }

    }
}
