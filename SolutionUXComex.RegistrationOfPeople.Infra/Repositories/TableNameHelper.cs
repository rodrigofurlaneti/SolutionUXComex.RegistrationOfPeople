using SolutionUXComex.RegistrationOfPeople.Domain.Attributes;
using SolutionUXComex.RegistrationOfPeople.Domain.Entities;

namespace SolutionUXComex.RegistrationOfPeople.Infra.Repositories
{
    public static class TableNameHelper
    {
        private static readonly Dictionary<Type, string> TableNames = new()
        {
            { typeof(PersonEntity), "Persons" } // Mapeia PersonEntity para "Persons"
        };

        public static string GetTableName<T>()
        {
            if (TableNames.TryGetValue(typeof(T), out string tableName))
            {
                return tableName;
            }

            throw new InvalidOperationException($"Nome da tabela não mapeado para o tipo {typeof(T).Name}");
        }
    }
}
