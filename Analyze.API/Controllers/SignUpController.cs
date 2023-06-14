using Microsoft.AspNetCore.Mvc;

namespace Analyze.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SignUpController : ControllerBase
{
    private readonly ILogger<SignUpController> _logger;

    public SignUpController(ILogger<SignUpController> logger)
	{
        _logger = logger;
	}
    
    [HttpPost(Name = "SignUp")]
    public IActionResult CreateAccount(SignUpRequest signUpRequest)
    {
        try
        {
            _logger.LogInformation("[{@Class}] - Request to create an account for {@Name} - {@DateTimeUtc}", typeof(SignUpController).Name, signUpRequest, DateTime.UtcNow);

            return CreatedAtAction(nameof(CreateAccount), new { signUpRequest.Name });
        } catch (Exception ex)
        {
            _logger.LogError("Request to create an account occurred an exception for {@Exception} - {@DateTimeUtc}", ex, DateTime.UtcNow);
            return BadRequest();
        }
    }
}

public class SignUpRequest
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Password { get; set; }
}