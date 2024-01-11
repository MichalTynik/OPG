package src;

public class Jedlo{
    private String nazovPotraviny;
    private int pocetKalorii;
    private double mnozstvoTuku;

    public Jedlo(String nazovPotraviny, int pocetKalorii, double mnozstvoTuku) {
        this.nazovPotraviny = nazovPotraviny;
        this.pocetKalorii = pocetKalorii;
        this.mnozstvoTuku = mnozstvoTuku;
    }

    public String getNazovPotraviny() {
        return nazovPotraviny;
    }

    public void setNazovPotraviny(String nazovPotraviny) {
        this.nazovPotraviny = nazovPotraviny;
    }

    public int getPocetKalorii() {
        return pocetKalorii;
    }

    public void setPocetKalorii(int pocetKalorii) {
        this.pocetKalorii = pocetKalorii;
    }

    public double getMnozstvoTuku() {
        return mnozstvoTuku;
    }

    public void setMnozstvoTuku(double mnozstvoTuku) {
        this.mnozstvoTuku = mnozstvoTuku;
    }

}

class Rastlinna extends Jedlo{
    private String typRastliny;
    public Rastlinna(String nazovPotraviny, int pocetKalorii, double mnozstvoTuku, String typRastliny) {
        super(nazovPotraviny, pocetKalorii, mnozstvoTuku);
        this.typRastliny = typRastliny;
    }
    public String getTypRastliny() {
        return typRastliny;
    }
    public void setTypRastliny(String typRastliny) {
        this.typRastliny = typRastliny;
    }

    

}
class Ovocie2 extends Rastlinna{
    private String nazov;
    private String odroda;
    public Ovocie2(String nazovPotraviny, int pocetKalorii, double mnozstvoTuku,String typRastliny, String nazov, String odroda) {
        super(nazovPotraviny, pocetKalorii, mnozstvoTuku, typRastliny);
        this.nazov = nazov;
        this.odroda = odroda;
    }
    public String getNazov() {
        return nazov;
    }
    public void setNazov(String nazov) {
        this.nazov = nazov;
    }
    public String getOdroda() {
        return odroda;
    }
    public void setOdroda(String odroda) {
        this.odroda = odroda;
    }

}

class Zivocisna extends Jedlo{
    private String druhPovodu;
    public Zivocisna(String nazovPotraviny, int pocetKalorii, double mnozstvoTuku, String druhPodvodu) {
        super(nazovPotraviny, pocetKalorii, mnozstvoTuku);
        this.druhPovodu = druhPodvodu;
    }
    public String getDruhPovodu() {
        return druhPovodu;
    }
    public void setDruhPovodu(String druhPovodu) {
        this.druhPovodu = druhPovodu;
    }

}