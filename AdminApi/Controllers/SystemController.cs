using Microsoft.AspNetCore.Mvc;

namespace AdminApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SystemController : ControllerBase
{
    [HttpGet("ActuatorInfo")]
    public IActionResult GetActuatorInfo()
    {
        return Redirect("/actuator/info");
    }

    [HttpGet("ActuatorHealth")]
    public IActionResult GetActuatorHealth()
    {
        return Redirect("/actuator/health");
    }
}
