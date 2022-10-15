namespace api;
//this is attractie cause i aint changing this shit
public class Vak{
    public int Id { get; set; }
    public string Naam { get; set; } = null!;
    public int Engheid {get; set;}
    public DateTime Bouwjaar {get; set;} = DateTime.Today;
}