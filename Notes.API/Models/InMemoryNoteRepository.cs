
namespace Notes.API.Models
{
    public class InMemoryNoteRepository : INoteRepository
    {
        private static List<Note> _notes = new List<Note>
        {
            new Note{ Id = 1, Title = "Note", Content = "Content"},
            new Note{ Id = 2, Title = "Note 2", Content = "Content 2"},
            new Note{ Id = 3, Title = "Note 3", Content = "Content 3"}
        };

        public IEnumerable<Note> GetAll()
        {
            return _notes;
        }

        public async Task<Note> GetByIdAsync(int id)
        {
            var note = _notes.Find(x => x.Id == id);
            return await Task.FromResult(note);
        }

        public async Task<Note> AddAsync(Note note)
        {
            note.Id = _notes.Max(x => x.Id) + 1;
            _notes.Add(note);

            return await Task.FromResult(note);
        }

        public async Task DeleteAsync(Note note)
        {
            _notes.Remove(note);
            await Task.Delay(0);
        }

        public async Task UpdateAsync(Note note)
        {
            var noteToUpdate = _notes.Find(x => x.Id == note.Id);
            noteToUpdate.Title = note.Title;
            noteToUpdate.Content = note.Content;
            await Task.Delay(0);
        }

    }
}
