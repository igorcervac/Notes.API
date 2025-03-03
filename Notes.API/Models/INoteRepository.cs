namespace Notes.API.Models
{
    public interface INoteRepository
    {
        IEnumerable<Note> GetAll();
        Task<Note> GetByIdAsync(int id);
        Task<Note> AddAsync(Note note);
        Task UpdateAsync(Note entity);
        Task DeleteAsync(Note entity);
    }
}
