using EventApi;
using Steeltoe.Management.Endpoint;
using Steeltoe.Messaging.RabbitMQ.Config;
using Steeltoe.Messaging.RabbitMQ.Extensions;

var builder = WebApplication.CreateBuilder(args);

var appConfig = builder.Configuration.Get<AppConfig>();

// Basic health check + info
builder.Host.AddHealthActuator();
builder.Host.AddInfoActuator();

// Setup rabbit
builder.Services.Configure<RabbitOptions>(builder.Configuration.GetSection(RabbitOptions.PREFIX));
builder.Services.AddRabbitServices();
builder.Services.AddRabbitAdmin();
builder.Services.AddRabbitTemplate();
builder.Services.AddRabbitQueue(new Queue(appConfig.EventQueueName));

builder.Services.AddSingleton(appConfig);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (appConfig.EnableSwagger)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();