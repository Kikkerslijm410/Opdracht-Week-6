using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api;

namespace Opdracht_Week_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VakkenController : ControllerBase
    {
        private readonly SchoolContext _context;

        public VakkenController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/Vakken
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vak>>> GetVak()
        {
          if (_context.Vak == null)
          {
              return NotFound();
          }
            return await _context.Vak.ToListAsync();
        }

        // GET: api/Vakken/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vak>> GetVak(int id)
        {
          if (_context.Vak == null)
          {
              return NotFound();
          }
            var vak = await _context.Vak.FindAsync(id);

            if (vak == null)
            {
                return NotFound();
            }

            return vak;
        }

        // PUT: api/Vakken/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVak(int id, Vak vak)
        {
            if (id != vak.Id)
            {
                return BadRequest();
            }

            _context.Entry(vak).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VakExists(id))
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

        // POST: api/Vakken
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vak>> PostVak(Vak vak)
        {
          if (_context.Vak == null)
          {
              return Problem("Entity set 'SchoolContext.Vak'  is null.");
          }
            _context.Vak.Add(vak);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVak", new { id = vak.Id }, vak);
        }

        // DELETE: api/Vakken/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVak(int id)
        {
            if (_context.Vak == null)
            {
                return NotFound();
            }
            var vak = await _context.Vak.FindAsync(id);
            if (vak == null)
            {
                return NotFound();
            }

            _context.Vak.Remove(vak);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VakExists(int id)
        {
            return (_context.Vak?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
