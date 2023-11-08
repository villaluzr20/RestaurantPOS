using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[AllowAnonymous]
[Microsoft.AspNetCore.Components.Route("api/public")]
public class PublicController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] User user)
    {        
        var tokenService = new TokenService();
        var token = tokenService.GenerateToken(user);
        if (token == null)
        {
            return Unauthorized();
        }

        return Ok(new { token });
    }
}
