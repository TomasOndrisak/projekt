using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PozicieController : ControllerBase
    {
        private readonly ZamestnanciContext _context;

        public PozicieController(ZamestnanciContext context)
        {
            _context = context;
        }

        // GET: api/Pozicie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pozicie>>> GetPozicie()
        {
            return await _context.Pozicie.ToListAsync();
        }

        // GET: api/Pozicie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pozicie>> GetPozicie(int id)
        {
            var pozicie = await _context.Pozicie.FindAsync(id);

            if (pozicie == null)
            {
                return NotFound();
            }

            return pozicie;
        }

        // PUT: api/Pozicie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPozicie(int id, Pozicie pozicie)
        {
            if (id != pozicie.Id)
            {
                return BadRequest();
            }

            _context.Entry(pozicie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PozicieExists(id))
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

        // POST: api/Pozicie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pozicie>> PostPozicie(Pozicie pozicie)
        {
            _context.Pozicie.Add(pozicie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPozicie", new { id = pozicie.Id }, pozicie);
        }

        // DELETE: api/Pozicie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePozicie(int id)
        {
            var pozicie = await _context.Pozicie.FindAsync(id);
            if (pozicie == null)
            {
                return NotFound();
            }

            _context.Pozicie.Remove(pozicie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PozicieExists(int id)
        {
            return _context.Pozicie.Any(e => e.Id == id);
        }
    }
}
