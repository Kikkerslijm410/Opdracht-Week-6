using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using api;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

[Route("api/[controller]")]
[ApiController]
public class LikeController : ControllerBase{
    private readonly PretparkContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public LikeController(PretparkContext context, UserManager<IdentityUser> usermanager){
        _context = context;
        _userManager = usermanager;
    }

    [HttpPost("{id}"), Authorize (Roles ="Gebruiker")]
    public async Task<ActionResult<List<Gebruiker>>> GetLike(int id){
        if (_context.Attractie == null){
            return NotFound();
        }
        var attractie = await _context.Attractie.Include("GLikes").SingleAsync(i => i.Id.Equals(id));
        if (attractie == null){
            return NotFound();
        }
        var HuidigeGebruiker = await _context.Gebruiker.SingleOrDefaultAsync(g => g.UserName == getUserName());
        if (HuidigeGebruiker == null){
            return NotFound();
        }
        // Debug
        Console.WriteLine(HuidigeGebruiker + " is aangemeld");
        // Verwijderd de like als de attractie al geliket is
        if(HuidigeGebruiker.GelikteAttracties.Where(a => a.Id == attractie.Id).Count() > 0){
            attractie.GLikes.Remove(HuidigeGebruiker);
            HuidigeGebruiker.GelikteAttracties.Remove(attractie);
        // Voegt de like toe
        }else{
            attractie.GLikes.Add(HuidigeGebruiker);
            HuidigeGebruiker.GelikteAttracties.Add(attractie);
        }
        await _context.SaveChangesAsync();
        return attractie.GLikes;
    }

    [HttpGet, Authorize(Roles = "Gebruiker")]
    public async Task<ActionResult<IEnumerable<Attractie>>> GetLikedAttractions(){
        var HuidigeGebruiker = await _context.Gebruiker.Include("GelikteAttracties").SingleOrDefaultAsync(g => g.UserName == getUserName());
        if(HuidigeGebruiker !=null){
            if(!await _userManager.IsInRoleAsync(HuidigeGebruiker, "Medewerker")){
                return HuidigeGebruiker.GelikteAttracties.ToList();
            }
        }
        return NotFound();
    }

    //needs testing
    private string getUserName(){
        //return User.Identity.Name;
        Request.Headers.TryGetValue("Authorization", out var headervalue);
        string cleanToken = headervalue.ToString().Substring(7);
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(cleanToken);
        var Token = jsonToken as JwtSecurityToken;
        string[] loggedInUserDisgusting = Token.Claims.ToList()[0].ToString().Split(": ");
        string loggedInUser = loggedInUserDisgusting[1];
        return loggedInUser;
    }
}