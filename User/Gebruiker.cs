using Microsoft.AspNetCore.Identity;
namespace api;

public class Gebruiker : IdentityUser{
    public string? Gebruikersname {get; set;}
    public string? Password {get; init;}
    public Geslacht geslacht {get; set;}
    public List<Attractie> GelikteAttracties =  new List<Attractie>();
}
