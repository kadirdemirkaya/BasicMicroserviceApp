using BasicMicroserviceApp.BuildingBlock.Base.Abstractions;
using BasicMicroserviceApp.BuildingBlock.Base.Configs;
using BasicMicroserviceApp.BuildingBlock.Base.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BasicMicroserviceApp.BuildingBlock.SqlServer
{
    public class WriteRepository<T> : IWriteRepository<T>
      where T : BaseEntity
    {
        private SqlPersistenceConnection persistenceConnection;
        private DbContext DbContext;

        public WriteRepository(DatabaseConfig databaseConfig, DbContext? dbContext)
        {
            if (databaseConfig.ConnectionString != null)
            {
                var connJson = JsonConvert.SerializeObject(databaseConfig.ConnectionString, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                });
                persistenceConnection = new SqlPersistenceConnection(databaseConfig, dbContext, 5);
                DbContext = persistenceConnection.GetContext;
            }
        }

        public WriteRepository(DatabaseConfig databaseConfig, DbContext? dbContext, IServiceProvider serviceProvider)
        {
            if (databaseConfig.ConnectionString != null)
            {
                var connJson = JsonConvert.SerializeObject(databaseConfig.ConnectionString, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                });
                persistenceConnection = new SqlPersistenceConnection(databaseConfig, dbContext, 5);
                DbContext = persistenceConnection.GetContext;
            }
        }

        private DbSet<T> _table => DbContext.Set<T>();

        public async Task<bool> CreateAsync(T entity)
        {
            try
            {
                await _table.AddAsync(entity);
                return true;
            }
            catch (System.Exception ex)
            {
                Serilog.Log.Error("MsSql Error : " + ex.Message);
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                _table.Remove(entity);
                return true;
            }
            catch (System.Exception ex)
            {
                Serilog.Log.Error("MsSql Error : " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteByIdAsync(T entityId)
        {
            try
            {
                _table.Remove(entityId);
                return true;
            }
            catch (System.Exception ex)
            {
                Serilog.Log.Error("MsSql Error : " + ex.Message);
                return false;
            }
        }

        public Task<bool> DeleteByIdAsync(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAsync(T entity)
        {
            try
            {
                _table.Update(entity);
                return true;
            }
            catch (System.Exception ex)
            {
                Serilog.Log.Error("MsSql Error : " + ex.Message);
                return false;
            }
        }

        Task<bool> IWriteRepository<T>.UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
