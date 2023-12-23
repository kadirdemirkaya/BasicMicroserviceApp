using BasicMicroserviceApp.BuildingBlock.Base.Models;

namespace BasicMicroserviceApp.BuildingBlock.Base.Abstractions
{
    public interface IMsSqlService<T>
      where T : BaseEntity
    {
    }
}
