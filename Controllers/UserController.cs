using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

[Authorize(Policy = "UserOnly")]
[Microsoft.AspNetCore.Components.Route("api/user")]
public class UserController : ControllerBase
{
    [HttpGet("get-orders")]
    public IActionResult GetOrders()
    {
        // Only users can get their orders
        if (!User.IsInRole("User"))
        {
            return Forbid();
        }
        // TODO: Implement logic to get user's orders

        return Ok();
        }
    }
