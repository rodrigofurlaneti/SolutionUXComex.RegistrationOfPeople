using Microsoft.EntityFrameworkCore;
using SolutionUXComex.RegistrationOfPeople.Domain.Entities;

namespace SolutionUXComex.RegistrationOfPeople.Infra.Data
{
    public class UXComexAppDbContext : DbContext
    {
        public UXComexAppDbContext(DbContextOptions<UXComexAppDbContext> options) : base(options)
        {
        }
        public DbSet<PersonEntity> Person { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("UXComex");
        }
    }
}


