namespace api;

public class Geslacht{
    public string geslacht {get; set;}

    public Geslacht (string g){
        if (g == null || (g != "Man" && g != "Vrouw" && g != "Anders")){
            geslacht = "Onbekend";
        }else{
            geslacht = g;
        }
    }
}