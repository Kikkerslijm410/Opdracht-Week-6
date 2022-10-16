using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace api;

[Owned]
public class Geslacht{
    [Required]
    [RegularExpression("Man | Vrouw | Onbekend | Anders", ErrorMessage =("Maak een juiste keuze") )]
    public string geslacht = "Onbekend";
}