using Microsoft.AspNetCore.Mvc;
using Steeltoe.Messaging.RabbitMQ.Core;

namespace EventApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly AppConfig _appConfig;
    private readonly RabbitTemplate _rabbitTemplate;

    public EventsController(AppConfig appConfig, RabbitTemplate rabbitTemplate)
    {
        _appConfig = appConfig;
        _rabbitTemplate = rabbitTemplate;
    }

    [HttpGet("Consume")]
    public IActionResult Consume()
    {
        return Ok(_rabbitTemplate.ReceiveAndConvert<string>(_appConfig.EventQueueName));
    }
}
