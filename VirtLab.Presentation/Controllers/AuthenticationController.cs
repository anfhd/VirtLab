using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

[Route("api/authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _service;
    public AuthenticationController(IServiceManager service)
        => _service = service;

    [HttpPost]
    public async Task<IActionResult> RegisterUser(
        [FromBody] UserForRegistrationDto userForRegistration)
    {
        var result = await _service.AuthenticationService.RegisterUser(userForRegistration);
        
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }

        var baseUser = await _service.AuthenticationService.GetUserByEmail(userForRegistration.Email);

        if (userForRegistration.Roles.Contains("Student"))
        {
            await _service.StudentService.CreateStudentAsync(userForRegistration, baseUser);
        }
        else if(userForRegistration.Roles.Contains("Teacher"))
        {
            await _service.TeacherService.CreateTeacherAsync(userForRegistration, baseUser);
        }

        return StatusCode(201);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
    {
        if (!await _service.AuthenticationService.ValidateUser(user))
            return Unauthorized();

        var foundedUser = await _service.AuthenticationService.GetUserByUsername(user.UserName);
        var role = await _service.AuthenticationService.GetUserRole(foundedUser);

        Guid foundedUserId = Guid.Empty;

        switch (role.ToLower())
        {
            case "student":
                var student = await _service.StudentService.GetStudentByBaseUserIdAsync(foundedUser.Id, trackChanges: false);
                foundedUserId = student.Id;
                break;
            case "teacher":
                var teacher = await _service.TeacherService.GetTeacherByBaseUserIdAsync(foundedUser.Id, trackChanges: false);
                foundedUserId = teacher.Id;
                break;
        }

        return Ok(new
        {
            Token = await _service.AuthenticationService.CreateToken(),
            UserId = foundedUserId,
            Role = role
        });
    }

}