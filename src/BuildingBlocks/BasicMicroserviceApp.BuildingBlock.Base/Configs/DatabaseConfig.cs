namespace BasicMicroserviceApp.BuildingBlock.Base.Configs
{
    public class DatabaseConfig
    {
        public object ConnectionString { get; set; }
        public int RetryCount { get; set; } = 5;
    }
}
