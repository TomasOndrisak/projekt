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
    public class ArchivovanyController : ControllerBase
    {
        private readonly ZamestnanciContext _context;

        public ArchivovanyController(ZamestnanciContext context)
        {
            _context = context;
        }

        // GET: api/Archivovany
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Archivovany>>> GetArchivovany()
        {
            return await _context.Archivovany.ToListAsync();
        }



        // GET: api/Archivovany/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Archivovany>> GetArchivovany(int id)
        {
            var archivovany = await _context.Archivovany.FindAsync(id);

            if (archivovany == null)
            {
                return NotFound();
            }

            return archivovany;
        }




        // PUT: api/Archivovany/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchivovany(int id, Archivovany archivovany)
        {
            if (id != archivovany.Id)
            {
                return BadRequest();
            }

            _context.Entry(archivovany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchivovanyExists(id))
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

        // POST: api/Archivovany
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Archivovany>> PostArchivovany(Archivovany archivovany)
        {
            _context.Archivovany.Add(archivovany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArchivovany", new { id = archivovany.Id }, archivovany);
        }

        // DELETE: api/Archivovany/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArchivovany(int id)
        {
            var archivovany = await _context.Archivovany.FindAsync(id);
            if (archivovany == null)
            {
                return NotFound();
            }

            _context.Archivovany.Remove(archivovany);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArchivovanyExists(int id)
        {
            return _context.Archivovany.Any(e => e.Id == id);
        }
    }
}
