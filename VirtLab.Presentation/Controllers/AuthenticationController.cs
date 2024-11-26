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

        if(userForRegistration.Roles.Contains("Student"))
        {
            _service.StudentService.CreateStudent(userForRegistration);
        }
        else if(userForRegistration.Roles.Contains("Teacher"))
        {
            _service.TeacherService.CreateTeacher(userForRegistration);
        }

        return StatusCode(201);
    }
}