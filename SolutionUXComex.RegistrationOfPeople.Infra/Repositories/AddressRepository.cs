using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;
using SolutionUXComex.RegistrationOfPeople.Domain.Entities;
using SolutionUXComex.RegistrationOfPeople.Domain.Interfaces;
using System.Data.Common;

namespace SolutionUXComex.RegistrationOfPeople.Infra.Repositories
{
    public class AddressRepository : RepositoryBase<AddressEntity>, IAddressRepository
    {
        private readonly ILogger<AddressRepository> _logger;

        public AddressRepository(IDbConnection dbConnection, ILogger<AddressRepository> logger)
            : base(dbConnection, logger)
        {
            _logger = logger;
        }

        public async Task<List<AddressEntity>> GetByPersonIdAsync(int personId)
        {
            try
            {
                string tableName = TableNameHelper.GetTableName<AddressEntity>();
                string sql = $"SELECT * FROM {tableName} WHERE PersonId = @PersonId";

                var addresses = await _dbConnection.QueryAsync<AddressEntity>(sql, new { PersonId = personId });
                return addresses.ToList();
            }
            catch (DbException ex)
            {
                _logger.LogError(ex, "Erro ao buscar {Entity} com PersonId {Id}", typeof(AddressEntity).Name, personId);
                return new List<AddressEntity>(); // Retorna lista vazia em caso de erro
            }
        }
    }
}