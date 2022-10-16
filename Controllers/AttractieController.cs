using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using api;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

[Route("api/[controller]")]
[ApiController]
public class AttractieController : ControllerBase{
    private readonly PretparkContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public AttractieController(PretparkContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // GET: api/Attractie
    [HttpGet, Authorize(Roles = "Medewerker")]
    public async Task<ActionResult<IEnumerable<Attractie>>> GetAttractie(){
        if (_context.Attractie == null)
        {
            return NotFound();
        }
        return await _context.Attractie.ToListAsync();
    }

    // ADD here all filters

    // GET: api/Attractie/5
    [HttpGet("{id}"), Authorize(Roles = "Medewerker")]
    public async Task<ActionResult<Attractie>> GetAttractie(int id){
        if (_context.Attractie == null){
            return NotFound();
        }
        var attractie = await _context.Attractie.FindAsync(id);
        if (attractie == null){
            return NotFound();
        }
        return attractie;
    }

    // PUT: api/Attractie/5
    [HttpPut("{id}"), Authorize(Roles = "Medewerker")]
    public async Task<IActionResult> PutAttractie(int id, Attractie attractie){
        if (id != attractie.Id){
            return BadRequest();
        }
        _context.Entry(attractie).State = EntityState.Modified;
        try{
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException){
            if (!AttractieExists(id)){
                return NotFound();
            }
            else{
                throw;
            }
        }
        return NoContent();
    }

    // POST: api/Attractie
    [HttpPost, Authorize(Roles = "Medewerker")]
    public async Task<ActionResult<Attractie>> PostAttractie(Attractie attractie){
        if (_context.Attractie == null){
            return Problem("Entity set 'SchoolContext.Attractie' is null.");
        }
        _context.Attractie.Add(attractie);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetAttractie", new { id = attractie.Id }, attractie);
    }

    // DELETE: api/Attractie/5
    [HttpDelete("{id}"), Authorize(Roles = "Medewerker")]
    public async Task<IActionResult> DeleteAttractie(int id){
        if (_context.Attractie == null){
            return NotFound();
        }
        var attractie = await _context.Attractie.FindAsync(id);
        if (attractie == null){
            return NotFound();
        }
        _context.Attractie.Remove(attractie);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool AttractieExists(int id){
        return (_context.Attractie?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
