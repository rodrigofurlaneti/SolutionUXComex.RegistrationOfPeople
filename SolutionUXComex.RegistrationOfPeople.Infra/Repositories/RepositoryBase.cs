using Microsoft.EntityFrameworkCore;
using SolutionUXComex.RegistrationOfPeople.Infra.Data;
using SolutionUXComex.RegistrationOfPeople.Domain.Interfaces;

namespace SolutionUXComex.RegistrationOfPeople.Infra.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly UXComexAppDbContext _context;

        public RepositoryBase(UXComexAppDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> GetByNameAsync(string name)
        {
            return await _context.Set<T>().AnyAsync(e => EF.Property<string>(e, "Name") == name);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log ou inspecione a exceção
                var errorMessage = ex.InnerException?.Message;
                // Trate a exceção ou registre o erro
            }
        }

        public async Task<int> AddReturnIdAsync(T entity)
        {
            // Adiciona a entidade ao contexto
            await _context.Set<T>().AddAsync(entity);

            // Salva as mudanças no banco de dados
            await _context.SaveChangesAsync();

            // Supondo que sua entidade tenha uma propriedade chamada "Id" ou algo equivalente
            // Use reflexão para acessar a propriedade Id
            var propertyInfo = typeof(T).GetProperty("Id");

            if (propertyInfo == null)
            {
                throw new InvalidOperationException("A entidade não possui uma propriedade 'Id'.");
            }

            // Retorna o valor do Id como um inteiro
            return (int)propertyInfo.GetValue(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
