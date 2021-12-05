using AdminApi.Entities;
using Steeltoe.Messaging.RabbitMQ.Core;

namespace AdminApi.Messaging
{
    public class EventHelper : IEventHelper
    {
        private readonly AppConfig _appConfig;
        private readonly RabbitTemplate _rabbitTemplate;
        private readonly ILogger _logger;

        public EventHelper(AppConfig appConfig, IDbContext context, RabbitTemplate rabbitTemplate, ILogger<EventHelper> logger)
        {
            _appConfig = appConfig;
            _rabbitTemplate = rabbitTemplate;
            _logger = logger;
        }

        public void Raise(User user, UserEvent.State state)
        {
            var userEvent = new UserEvent(state, user);

            _rabbitTemplate.ConvertAndSend(_appConfig.EventQueueName, userEvent.ToJsonString());

            _logger.LogInformation($"Raised an event for user #{user.Id}.");
        }
    }
}