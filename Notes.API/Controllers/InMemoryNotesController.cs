using Microsoft.AspNetCore.Mvc;
using Notes.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Notes.API.Controllers
{
    [Route("api/notes-mem")]
    [ApiController]
    public class InMemoryNotesController : ControllerBase
    {
        private static List<Note> _notes = new List<Note>
        {
            new Note{ Id = 1, Title = "Note", Content = "Content"},
            new Note{ Id = 2, Title = "Note 2", Content = "Content 2"},
            new Note{ Id = 3, Title = "Note 3", Content = "Content 3"}
        };

        public InMemoryNotesController()
        {
        }

        // GET: api/<NotesController>
        [HttpGet]
        public ActionResult<IEnumerable<Note>> GetAll()
        {
            return Ok(_notes);
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var note = _notes.Find(x => x.Id == id);
            if (note == null)
            {
                return NotFound();
            }

            return await Task.FromResult(Ok(note));
        }

        // POST api/<NotesController>
        [HttpPost]
        public async Task<ActionResult<Note>> Post([FromBody] Note note)
        {
            note.Id = _notes.Max(x => x.Id) + 1;
            _notes.Add(note);

            return await Task.FromResult(CreatedAtAction(nameof(GetById), new { note.Id }, note));
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Note note)
        {
            if (id != note.Id)
            {
                return BadRequest();
            }

            var noteToUpdate = _notes.Find(x => x.Id == id);

            if (noteToUpdate == null)
            {
                return NotFound();
            }

            noteToUpdate.Title = note.Title;
            noteToUpdate.Content = note.Content;

            return await Task.FromResult(NoContent());
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var noteToDelete = _notes.Find(x => x.Id == id);

            if (noteToDelete == null)
            {
                return NotFound();
            }

            _notes.Remove(noteToDelete);

            return await Task.FromResult(NoContent());
        }
    }
}
