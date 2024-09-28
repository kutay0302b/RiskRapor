using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiskRapor.Data;
using RiskRapor.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRapor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaliBilgilerApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MaliBilgilerApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MaliBilgiler
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaliBilgiler>>> GetMaliBilgiler()
        {
            return await _context.MaliBilgiler.ToListAsync();
        }

        // GET: api/MaliBilgiler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaliBilgiler>> GetMaliBilgiler(int id)
        {
            var maliBilgi = await _context.MaliBilgiler.FindAsync(id);

            if (maliBilgi == null)
            {
                return NotFound();
            }

            return maliBilgi;
        }

        // PUT: api/MaliBilgiler/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaliBilgiler(int id, MaliBilgiler maliBilgi)
        {
            if (id != maliBilgi.Id)
            {
                return BadRequest();
            }

            _context.Entry(maliBilgi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaliBilgilerExists(id))
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

        // POST: api/MaliBilgiler
        [HttpPost]
        public async Task<ActionResult<MaliBilgiler>> PostMaliBilgiler(MaliBilgiler maliBilgi)
        {
            _context.MaliBilgiler.Add(maliBilgi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaliBilgiler", new { id = maliBilgi.Id }, maliBilgi);
        }

        // DELETE: api/MaliBilgiler/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaliBilgiler(int id)
        {
            var maliBilgi = await _context.MaliBilgiler.FindAsync(id);
            if (maliBilgi == null)
            {
                return NotFound();
            }

            _context.MaliBilgiler.Remove(maliBilgi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaliBilgilerExists(int id)
        {
            return _context.MaliBilgiler.Any(e => e.Id == id);
        }
    }
}
