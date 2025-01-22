using Microsoft.AspNetCore.Mvc;
using Notes.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Notes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        //private static List<Note> _notes = new List<Note>
        //{
        //    new Note{ Id = 1, Title = "Note", Content = "Content"},
        //    new Note{ Id = 2, Title = "Note 2", Content = "Content 2"},
        //    new Note{ Id = 3, Title = "Note 3", Content = "Content 3"}
        //};
        private readonly Subscription1DbContext _context;

        public NotesController(Subscription1DbContext context)
        {
            _context = context;
        }

        // GET: api/<NotesController>
        [HttpGet]
        public IEnumerable<Note> Get()
        {
            //return _notes;
            return _context.Notes;
        }

        //// GET api/<NotesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<NotesController>
        [HttpPost]
        public Note Post([FromBody] Note note)
        {
            //note.Id = _notes.Max(x => x.Id) + 1;
            //_notes.Add(note);
            _context.Notes.Add(note);
            _context.SaveChanges();

            return note;
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Note note)
        {
            //var noteToUpdate = _notes.Find(x => x.Id == id);
            var noteToUpdate = _context.Notes.Find(id);
            noteToUpdate.Title = note.Title;
            noteToUpdate.Content = note.Content;
            _context.SaveChanges();

        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //var noteToDelete = _notes.Find(x => x.Id == id);
            var noteToDelete = _context.Notes.Find(id);
            //_notes.Remove(noteToDelete);
            _context.Notes.Remove(noteToDelete);
            _context.SaveChanges();
        }
    }
}
