using Microsoft.AspNetCore.Identity;
namespace api;

public class Gebruiker : IdentityUser{
    public string password {get; init;} = null!;
    public Geslacht geslacht {get; set;} = null!;
    public List<Attractie> GelikteAttracties =  new List<Attractie>();
}
