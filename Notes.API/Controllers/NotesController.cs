using Microsoft.AspNetCore.Mvc;
using Notes.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Notes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public NotesController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        // GET: api/<NotesController>
        [HttpGet]
        public ActionResult<IEnumerable<Note>> GetAll()
        {
            return Ok(_noteRepository.GetAll());
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var note = await _noteRepository.GetByIdAsync(id);
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
            var addedNote = await _noteRepository.AddAsync(note);

            return CreatedAtAction(nameof(GetById), new { addedNote.Id }, addedNote);
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Note note)
        {
            if (id != note.Id)
            {
                return BadRequest();
            }

            var noteToUpdate = await _noteRepository.GetByIdAsync(id);

            if (noteToUpdate == null)
            {
                return NotFound();
            }

            await _noteRepository.UpdateAsync(noteToUpdate);  

            return NoContent();

        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var noteToDelete = await _noteRepository.GetByIdAsync(id);

            if (noteToDelete == null)
            {
                return NotFound();
            }

            await _noteRepository.DeleteAsync(noteToDelete);

            return NoContent() ;
        }
    }
}
