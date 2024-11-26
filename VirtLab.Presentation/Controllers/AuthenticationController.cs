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

        var baseUser = await _service.AuthenticationService.GetUser(userForRegistration.Email);

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
}