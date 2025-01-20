using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Notes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private static List<Note> _notes = new List<Note>
        {
            new Note{ Id = 1, Title = "Note", Content = "Content"},
            new Note{ Id = 2, Title = "Note 2", Content = "Content 2"},
            new Note{ Id = 3, Title = "Note 3", Content = "Content 3"}
        };

        // GET: api/<NotesController>
        [HttpGet]
        public IEnumerable<Note> Get()
        {
            return _notes;
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NotesController>
        [HttpPost]
        public void Post([FromBody] Note note)
        {
            _notes.Add(note);
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Note note)
        {
            var noteToUpdate = _notes.Find(x => x.Id == id);
            noteToUpdate.Title = note.Title;
            noteToUpdate.Content = note.Content;
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var noteToDelete = _notes.Find(x => x.Id == id);
            _notes.Remove(noteToDelete);
        }
    }
}
