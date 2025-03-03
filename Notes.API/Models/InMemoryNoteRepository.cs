
namespace Notes.API.Models
{
    public class InMemoryNoteRepository : INoteRepository
    {
        private static List<Note> _notes = Enumerable.Range(1, 5)
                .Select(x => new Note { Id = x, Title = $"Title {x}", Content = $"Content {x}" })
                .ToList();

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
            var noteToUpdate = await GetByIdAsync(note.Id);

            noteToUpdate.Title = note.Title;
            noteToUpdate.Content = note.Content;

            await Task.Delay(0);
        }

    }
}
