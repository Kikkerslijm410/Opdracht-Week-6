namespace api;

[Microsoft.EntityFrameworkCore.Owned]
public class Geslacht{
    public string geslacht;
    public void SetGeslacht (string g){
        if (g == null || (g != "Man" && g != "Vrouw" && g != "Anders")){
            geslacht = "Onbekend";
        }else{
            geslacht = g;
        }
    }
}