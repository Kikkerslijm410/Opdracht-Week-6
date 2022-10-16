using Microsoft.EntityFrameworkCore;

namespace api;

[Owned]
public class Geslacht{
    public string geslacht = "Onbekend";
    public void SetGeslacht (string g){
        if (g == null || (g != "Man" && g != "Vrouw" && g != "Anders")){
            geslacht = "Onbekend";
        }else{
            geslacht = g;
        }
    }
}