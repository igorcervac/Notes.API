namespace Notes.API.Models
{
    public class NoteRepository : IGenericRepository<Note>
    {
        private readonly Subscription1DbContext _context;

        public NoteRepository(Subscription1DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Note> GetAll()
        {
            return _context.Notes;
        }

        public async Task<Note> GetByIdAsync(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            return note;
        }

        public async Task<Note> AddAsync(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return note;
        }

        public async Task DeleteAsync(Note note)
        {
           _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        } 

        public async Task UpdateAsync(Note note)
        {
            _context.Entry(note).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
