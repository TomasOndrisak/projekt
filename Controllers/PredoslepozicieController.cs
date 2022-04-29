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
    public class PredoslepozicieController : ControllerBase
    {
        private readonly ZamestnanciContext _context;

        public PredoslepozicieController(ZamestnanciContext context)
        {
            _context = context;
        }

        // GET: api/Predoslepozicie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Predoslepozicie>>> GetPredoslepozicie()
        {
            return await _context.Predoslepozicie.ToListAsync();
        }


      



        // GET: api/Predoslepozicie/5
        [HttpGet("{idZamestnanca}")]
        public async Task<ActionResult<Predoslepozicie>> GetPredoslepozicie(int idZamestnanca)
        {
            var Predoslepozicie = _context.Predoslepozicie.Where(id => id.idZamestnanca == idZamestnanca).ToList();

            if (Predoslepozicie == null)
            {
                return NotFound();
            }

            return Ok(Predoslepozicie);
        }

     

        // PUT: api/Predoslepozicie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPredoslepozicie(int id, Predoslepozicie Predoslepozicie)
        {
            if (id != Predoslepozicie.Id)
            {
                return BadRequest();
            }

            _context.Entry(Predoslepozicie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PredoslepozicieExists(id))
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

        // POST: api/Predoslepozicie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Predoslepozicie>> PostPredoslepozicie(Predoslepozicie Predoslepozicie)
        {
            _context.Predoslepozicie.Add(Predoslepozicie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPredoslepozicie", new { id = Predoslepozicie.Id }, Predoslepozicie);
        }

        // DELETE: api/Predoslepozicie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePredoslepozicie(int id)
        {
            var Predoslepozicie = await _context.Predoslepozicie.FindAsync(id);
            if (Predoslepozicie == null)
            {
                return NotFound();
            }

            _context.Predoslepozicie.Remove(Predoslepozicie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PredoslepozicieExists(int id)
        {
            return _context.Predoslepozicie.Any(e => e.Id == id);
        }
    }
}
