namespace BasicMicroserviceApp.BuildingBlock.Base.Configs
{
    public class InMemoryConfig
    {
        public object Connection { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RetryCount { get; set; } = 5;
    }
}
