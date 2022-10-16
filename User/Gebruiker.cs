using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace api;

public class Gebruiker : IdentityUser{
    public string? password {get; init;}
    public Geslacht geslacht {get;set;} = new Geslacht();
    public List<Attractie> GelikteAttracties =  new List<Attractie>();
}

public class GebruikerLogin{
    [Required(ErrorMessage = "Username is required")]
    public string? UserName { get; init; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; init; }
}