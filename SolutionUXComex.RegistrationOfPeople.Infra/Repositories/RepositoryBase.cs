using Dapper;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Common;
using Microsoft.Extensions.Logging;
using SolutionUXComex.RegistrationOfPeople.Domain.Interfaces;

namespace SolutionUXComex.RegistrationOfPeople.Infra.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<RepositoryBase<T>> _logger;

        public RepositoryBase(IDbConnection dbConnection, ILogger<RepositoryBase<T>> logger)
        {
            _dbConnection = dbConnection;
            _logger = logger;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                string sql = $"SELECT * FROM {typeof(T).Name} WHERE Id = @Id";
                return await _dbConnection.QueryFirstOrDefaultAsync<T>(sql, new { Id = id });
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, "Erro ao buscar {Entity} com Id {Id}", typeof(T).Name, id);
                return null;
            }
        }

        public async Task<bool> GetByNameAsync(string name)
        {
            try
            {
                string sql = $"SELECT COUNT(1) FROM {typeof(T).Name} WHERE Name = @Name";
                int count = await _dbConnection.ExecuteScalarAsync<int>(sql, new { Name = name });
                return count > 0;
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, "Erro ao verificar existência da entidade {Entity} com Nome {Name}", typeof(T).Name, name);
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                string sql = $"SELECT * FROM {typeof(T).Name}";
                return await _dbConnection.QueryAsync<T>(sql);
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, "Erro ao buscar todas as entidades do tipo {Entity}", typeof(T).Name);
                return new List<T>();
            }
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                string sql = $"INSERT INTO {typeof(T).Name} DEFAULT VALUES;";
                await _dbConnection.ExecuteAsync(sql, entity);
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, "Erro ao adicionar uma nova entidade {Entity}", typeof(T).Name);
            }
        }

        public async Task<int> AddReturnIdAsync(T entity)
        {
            try
            {
                string sql = $"INSERT INTO {typeof(T).Name} OUTPUT INSERTED.Id DEFAULT VALUES;";
                return await _dbConnection.ExecuteScalarAsync<int>(sql, entity);
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, "Erro ao adicionar uma nova entidade {Entity} e obter ID", typeof(T).Name);
                return -1;
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                string sql = $"UPDATE {typeof(T).Name} SET /* Definir colunas */ WHERE Id = @Id";
                await _dbConnection.ExecuteAsync(sql, entity);
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, "Erro ao atualizar a entidade {Entity}", typeof(T).Name);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                string sql = $"DELETE FROM {typeof(T).Name} WHERE Id = @Id";
                await _dbConnection.ExecuteAsync(sql, new { Id = id });
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, "Erro ao excluir a entidade {Entity} com Id {Id}", typeof(T).Name, id);
            }
        }
    }
}
