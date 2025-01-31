using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace SolutionUXComex.RegistrationOfPeople.Infra
{
    public class DatabaseInitializer
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<DatabaseInitializer> _logger;
        private readonly string _scriptsPath;

        public DatabaseInitializer(IDbConnection dbConnection, ILogger<DatabaseInitializer> logger, IConfiguration configuration)
        {
            _dbConnection = dbConnection;
            _logger = logger;
            _scriptsPath = Path.Combine(Directory.GetCurrentDirectory(), "Scripts/Migrations");
        }

        public async Task ApplyMigrationsAsync()
        {
            try
            {
                _logger.LogInformation("Iniciando a execução das migrations...");

                var scriptPath = Path.Combine(_scriptsPath, "V1_InitialMigration.sql");
                if (File.Exists(scriptPath))
                {
                    var sql = await File.ReadAllTextAsync(scriptPath);
                    await _dbConnection.ExecuteAsync(sql);
                    _logger.LogInformation("Migration aplicada com sucesso.");
                }
                else
                {
                    _logger.LogWarning("Arquivo de migration não encontrado.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao aplicar migrations.");
                throw;
            }
        }
    }
}
