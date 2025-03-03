namespace Notes.API.Models
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T note);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
