using System.ComponentModel.DataAnnotations.Schema;

namespace api;
//this is attractie cause i aint changing this shit
//Ok so i changed it cause autism
public class Attractie{
    public int Id {get; set;}
    public string Naam {get; set;} = null!;
    public int Engheid {get; set;}
    public DateTime Bouwjaar {get; set;}
        
    [NotMapped]
    public int like {get;set;}
    [NotMapped]
    public List<Gebruiker> GLikes {get;set;} 
}