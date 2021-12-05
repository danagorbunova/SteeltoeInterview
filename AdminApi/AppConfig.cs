namespace AdminApi
{
    public class AppConfig
    {
        public bool EnableSwagger { get; set; }
        public string DbConnectionString { get; set; }
        public string EventQueueName { get; set; }
    }
}