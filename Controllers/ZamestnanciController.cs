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
    public class ZamestnanciController : ControllerBase
    {
        private readonly ZamestnanciContext _context;

        public ZamestnanciController(ZamestnanciContext context)
        {
            _context = context;
        }

        // GET: api/Zamestnanci
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zamestnanci>>> GetZamestnanci()
        {
            return await _context.Zamestnanci.ToListAsync();
        }
        
        // select id, meno, priezvisko, pozicia
        [HttpGet("/api/zamestnancizoznam")]
        public dynamic GetZamestnancizoznam()
        {
            return _context.Zamestnanci
              .Select(x => new
              {  
                  x.Id,
                  x.Meno,
                  x.Priezvisko,
                  x.Pozicia
              }).ToArray();
        }




        // GET: api/Zamestnanci/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zamestnanci>> GetZamestnanci(int id)
        {
            var zamestnanci = await _context.Zamestnanci.FindAsync(id);

            if (zamestnanci == null)
            {
                return NotFound();
            }

            return zamestnanci;
        }

        // PUT: api/Zamestnanci/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZamestnanci(int id, Zamestnanci zamestnanci)
        {
            if (id != zamestnanci.Id)
            {
                return BadRequest();
            }

            _context.Entry(zamestnanci).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZamestnanciExists(id))
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

        // POST: api/Zamestnanci
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Zamestnanci>> PostZamestnanci(Zamestnanci zamestnanci)
        {
            _context.Zamestnanci.Add(zamestnanci);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZamestnanci", new { id = zamestnanci.Id }, zamestnanci);
        }

        // DELETE: api/Zamestnanci/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZamestnanci(int id)
        {
            var zamestnanci = await _context.Zamestnanci.FindAsync(id);
            if (zamestnanci == null)
            {
                return NotFound();
            }

            _context.Zamestnanci.Remove(zamestnanci);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZamestnanciExists(int id)
        {
            return _context.Zamestnanci.Any(e => e.Id == id);
        }
    }
}
