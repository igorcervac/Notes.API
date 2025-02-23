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
        public ActionResult<IEnumerable<Note>> GetAll()
        {
            return Ok(_context.Notes);
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        // POST api/<NotesController>
        [HttpPost]
        public async Task<ActionResult<Note>> Post([FromBody] Note note)
        {
            //note.Id = _notes.Max(x => x.Id) + 1;
            //_notes.Add(note);
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { note.Id }, note);
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Note note)
        {
            //var noteToUpdate = _notes.Find(x => x.Id == id);
            if (id != note.Id)
            {
                return BadRequest();
            }

            var noteToUpdate = await _context.Notes.FindAsync(id);

            if (noteToUpdate == null)
            {
                return NotFound();
            }

            noteToUpdate.Title = note.Title;
            noteToUpdate.Content = note.Content;
            await _context.SaveChangesAsync();

            return NoContent();

        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var noteToDelete = _notes.Find(x => x.Id == id);
            var noteToDelete = await _context.Notes.FindAsync(id);

            if (noteToDelete == null)
            {
                return NotFound();
            }

            //_notes.Remove(noteToDelete);
            _context.Notes.Remove(noteToDelete);
            await _context.SaveChangesAsync();

            return NoContent() ;
        }
    }
}
