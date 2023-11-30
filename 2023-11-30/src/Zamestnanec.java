package src;

public class Zamestnanec {
     private int id;
     private String meno;
     private double vyplata;

    public int GetId() {
        return id;
    }

    public String GetMeno() {
        return meno;
    }

    public double GetVyplata() {
        return vyplata;
    }

    public Zamestnanec(int id, String meno, double vyplata){
        this.id = id;
        this.meno = meno;
        this.vyplata = vyplata;
    }
    
    public void Set(int id, String meno, double vyplata) {
        this.id = id;
        this.meno = meno;
        this.vyplata = vyplata;
    }

    public void zobraz(int id, String meno, double vyplata){
        System.out.println("ID: " + id + " meno: " + meno + " vyplata: " + vyplata);
    }

}

/**
 * InnerZamestnanec
 */
class InnerZamestnanec {
    public static void main(String[] args) {
        Zamestnanec zm = new Zamestnanec(1, "Michal Tynik", 5000);
        Zamestnanec zm2 = new Zamestnanec(2, "Jakub Kulo", 3500);
        Zamestnanec zm3 = new Zamestnanec(3, "Lukas Mama", 2000);
        zm.zobraz(zm.GetId(), zm.GetMeno(), zm.GetVyplata());
        zm2.zobraz(zm2.GetId(), zm2.GetMeno(), zm2.GetVyplata());
        zm3.zobraz(zm3.GetId(), zm3.GetMeno(), zm3.GetVyplata());
    }
    
}
