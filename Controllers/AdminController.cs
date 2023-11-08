using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

[Authorize(Policy = "AdminOnly")]
[Microsoft.AspNetCore.Components.Route("api/admin")]
public class AdminController : ControllerBase
{
[HttpPost("create-user")]
public IActionResult CreateUser([FromBody] User user)
{
    // Only admins can create users
    if (!User.IsInRole("Admin"))
    {
        return Forbid();
    }

    // TODO: Implement user creation logic

    return Ok();
}
}
