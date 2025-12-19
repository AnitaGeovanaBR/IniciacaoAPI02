using Domain.Entities;
using Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IniciacaoAPI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BibliotecaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BibliotecaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/biblioteca
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Biblioteca>>> GetBibliotecas()
        {
            return await _context.Biblioteca.ToListAsync();
        }

        // GET: api/biblioteca/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Biblioteca>> GetBiblioteca(Guid id)
        {
            var biblioteca = await _context.Biblioteca.FindAsync(id);

            if (biblioteca == null)
            {
                return NotFound();
            }

            return biblioteca;
        }

        // POST: api/biblioteca
        [HttpPost]
        public async Task<ActionResult<Biblioteca>> PostBiblioteca(Biblioteca biblioteca)
        {
            // Sempre gera um novo ID
            biblioteca.IdBiblioteca = Guid.NewGuid();

            _context.Biblioteca.Add(biblioteca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBiblioteca", new { id = biblioteca.IdBiblioteca }, biblioteca);
        }

        // PUT: api/biblioteca/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBiblioteca(Guid id, Biblioteca biblioteca)
        {
            if (id != biblioteca.IdBiblioteca)
            {
                return BadRequest();
            }

            _context.Entry(biblioteca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BibliotecaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/biblioteca/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBiblioteca(Guid id)
        {
            var biblioteca = await _context.Biblioteca.FindAsync(id);
            if (biblioteca == null)
            {
                return NotFound();
            }

            _context.Biblioteca.Remove(biblioteca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BibliotecaExists(Guid id)
        {
            return _context.Biblioteca.Any(e => e.IdBiblioteca == id);
        }
    }
}
