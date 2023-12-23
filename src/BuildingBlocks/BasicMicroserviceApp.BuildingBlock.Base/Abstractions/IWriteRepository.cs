using BasicMicroserviceApp.BuildingBlock.Base.Models;

namespace BasicMicroserviceApp.BuildingBlock.Base.Abstractions
{
    public interface IWriteRepository<T> where T : BaseEntity
    {
        public Task<bool> CreateAsync(T entity);
        public Task<bool> DeleteByIdAsync(Guid entityId);
        public Task<bool> UpdateAsync(T entity);
    }
}
