namespace SolutionUXComex.RegistrationOfPeople.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<bool> GetByNameAsync(string name);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<int> AddReturnIdAsync(T entity);
    }
}
