namespace BasicMicroserviceApp.BuildingBlock.Base.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
