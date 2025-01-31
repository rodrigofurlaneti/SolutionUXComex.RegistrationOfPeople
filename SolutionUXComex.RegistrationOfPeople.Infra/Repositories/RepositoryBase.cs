using Dapper;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Common;
using Microsoft.Extensions.Logging;
using SolutionUXComex.RegistrationOfPeople.Domain.Interfaces;
using static Dapper.Contrib.Extensions.SqlMapperExtensions;
using System.Reflection;

namespace SolutionUXComex.RegistrationOfPeople.Infra.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly IDbConnection _dbConnection; // 🔹 Agora protegido, permitindo acesso em classes derivadas
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
                string tableName = TableNameHelper.GetTableName<T>();
                string sql = $"SELECT * FROM {tableName} WHERE Id = @Id";
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
                string tableName = TableNameHelper.GetTableName<T>();
                string sql = $"SELECT COUNT(1) FROM {tableName} WHERE Name = @Name";
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
                string tableName = TableNameHelper.GetTableName<T>();
                string sql = $"SELECT * FROM {tableName}";
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
                string tableName = TableNameHelper.GetTableName<T>();

                // Obtém as propriedades da entidade
                var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name != "Id") // Ignora a propriedade Id (gerada pelo banco de dados)
                    .ToList();

                // Cria a lista de colunas e valores para a consulta SQL
                var columns = string.Join(", ", properties.Select(p => p.Name));
                var values = string.Join(", ", properties.Select(p => $"@{p.Name}"));

                // Monta a consulta SQL
                string sql = $@"
                    INSERT INTO {tableName} ({columns})
                    VALUES ({values});
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";
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
                string tableName = TableNameHelper.GetTableName<T>();

                // Obtém as propriedades da entidade
                var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name != "Id") // Ignora a propriedade Id (gerada pelo banco de dados)
                    .ToList();

                // Cria a lista de colunas e valores para a consulta SQL
                var columns = string.Join(", ", properties.Select(p => p.Name));
                var values = string.Join(", ", properties.Select(p => $"@{p.Name}"));


                // Monta a consulta SQL
                string sql = $@"
                    INSERT INTO {tableName} ({columns})
                    VALUES ({values});
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                // Executa a consulta e retorna o ID gerado
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
                string tableName = TableNameHelper.GetTableName<T>();

                // Suponha que você tenha uma lista de propriedades
                // Obtém as propriedades da entidade
                var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name != "Id") // Ignora a propriedade Id (gerada pelo banco de dados)
                    .ToList();

                // Cria a lista de colunas e valores para a consulta SQL
                var columns = string.Join(", ", properties.Select(p => p.Name));
                var values = string.Join(", ", properties.Select(p => $"@{p.Name}"));

                string query = $"UPDATE {tableName} SET ";

                // Itera sobre cada propriedade
                foreach (var prop in properties)
                {
                    // Adiciona o nome da propriedade como coluna
                    // Adiciona o valor da propriedade como parâmetro SQL
                    query += $"{prop.Name} = @{prop.Name}";

                    // Verifica se não é o último item
                    if (!prop.Equals(properties.Last()))
                    {
                        query += ", ";
                    }
                }

                query += " WHERE Id = @Id";

                // Agora você pode usar columnsString e valuesString na sua consulta SQL
                await _dbConnection.ExecuteAsync(query, entity);
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
                string tableName = TableNameHelper.GetTableName<T>();
                string sql = $"DELETE FROM {tableName} WHERE Id = @Id";
                await _dbConnection.ExecuteAsync(sql, new { Id = id });
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, "Erro ao excluir a entidade {Entity} com Id {Id}", typeof(T).Name, id);
            }
        }
    }
}