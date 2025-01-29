using Microsoft.EntityFrameworkCore;
using SolutionUXComex.RegistrationOfPeople.Domain.Entities;

namespace SolutionUXComex.RegistrationOfPeople.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<PersonEntity> Person { get; set; } = null!;
    }
}


