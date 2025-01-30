using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace SolutionUXComex.RegistrationOfPeople.Infra.Data
{
    public class AuthenticationDbContextFactory : IDesignTimeDbContextFactory<UXComexAppDbContext>
    {
        public UXComexAppDbContext CreateDbContext(string[] args)
        {
            string defaultConnection = "Server=rodrigofurlaneti3108_Finance.sqlserver.dbaas.com.br,1433;Database=rodrigofurlaneti3108_Finance;User Id=rodrigofurlaneti3108_Finance;Password=Digo310884@;";
            var optionsBuilder = new DbContextOptionsBuilder<UXComexAppDbContext>();
            optionsBuilder.UseSqlServer(defaultConnection);
            return new UXComexAppDbContext(optionsBuilder.Options);
        }
    }
}
