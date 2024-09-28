using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiskRapor.Data;
using RiskRapor.Models;
using System.Threading.Tasks;

namespace RiskRapor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnlasmalarApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnlasmalarApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Anlasmalar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anlasmalar>>> GetAnlasmalar()
        {
            return await _context.Anlasmalar.ToListAsync();
        }

        // GET: api/Anlasmalar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Anlasmalar>> GetAnlasmalar(int id)
        {
            var anlasma = await _context.Anlasmalar.FindAsync(id);

            if (anlasma == null)
            {
                return NotFound();
            }

            return anlasma;
        }

        // PUT: api/Anlasmalar/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnlasmalar(int id, Anlasmalar anlasma)
        {
            if (id != anlasma.AnlasmaId)
            {
                return BadRequest();
            }

            _context.Entry(anlasma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnlasmaExists(id))
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

        // POST: api/Anlasmalar
        [HttpPost]
        public async Task<ActionResult<Anlasmalar>> PostAnlasmalar(Anlasmalar anlasma)
        {
            _context.Anlasmalar.Add(anlasma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnlasmalar", new { id = anlasma.AnlasmaId }, anlasma);
        }

        // DELETE: api/Anlasmalar/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnlasmalar(int id)
        {
            var anlasma = await _context.Anlasmalar.FindAsync(id);
            if (anlasma == null)
            {
                return NotFound();
            }

            _context.Anlasmalar.Remove(anlasma);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnlasmaExists(int id)
        {
            return _context.Anlasmalar.Any(e => e.AnlasmaId == id);
        }
    }
}
