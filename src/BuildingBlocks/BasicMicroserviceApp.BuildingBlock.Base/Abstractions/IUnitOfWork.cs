using BasicMicroserviceApp.BuildingBlock.Base.Models;

namespace BasicMicroserviceApp.BuildingBlock.Base.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        IReadRepository<T> GetReadRepository<T>() where T : BaseEntity, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : BaseEntity, new();
    }
}
