using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using api;
using Microsoft.AspNetCore.Identity;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase{
    private readonly PretparkContext _context;
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleController(PretparkContext context, RoleManager<IdentityRole> roleManager){
        _context = context;
        _roleManager = roleManager;
    }

    // GET: api/Role
    [HttpGet]
    public async Task<ActionResult<IEnumerable<IdentityRole>>> GetAttractie(){
        if (_context.Roles == null){
            return NotFound();
        }
        return await _context.Roles.ToListAsync();
    }

    // GET: api/Role/5
    [HttpGet("{id}")]
    public async Task<ActionResult<IdentityRole>> GetRole(int id){
        if (_context.Roles == null){
            return NotFound();
        }
        var role = await _context.Roles.FindAsync(id);
        if (role == null){
            return NotFound();
        }
        return role;
    }

    // POST: api/Role
    [HttpPost]
    public async Task<ActionResult<IdentityRole>> PostRole(IdentityRole role){
        if (_context.Roles == null){
            return Problem("Entity set 'SchoolContext.Role' is null.");
        } 
        await _roleManager.CreateAsync(role);
        if (RoleExists(role.Id)){
            return Conflict();
        }else{
            await _context.SaveChangesAsync();   
        }
        return CreatedAtAction("GetRole", new { id = role.Id }, role);
    }

    // DELETE: api/Role/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAttractie(int id){
        if (_context.Roles == null){
            return NotFound();
        }
        var role = await _context.Roles.FindAsync(id);
        if (role == null)
        {
            return NotFound();
        }
        await _roleManager.DeleteAsync(role);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RoleExists(string id){
        return (_roleManager.Roles?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}