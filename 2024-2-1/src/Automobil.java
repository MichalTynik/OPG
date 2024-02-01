package src;

import java.util.List;
import java.util.ArrayList;
class Test {
    public static void main(String[] args) {
    List<Automobil> auto = new ArrayList<Automobil>();
    auto.add(new Automobil("Volv","Nakladne", 2013, "biela"));
    auto.add(new Osobny(5,7,"Skoda","Superb",2018, "biela"));
    Automobil auto1 = auto.get(0);
    auto1.vypis();
}
}

class Automobil {
    String znacka;
    String model;
    int rokVyroby;
    String farba;

    Automobil(String znacka, String model, int rokVyroby, String farba) {
        this.znacka = znacka;
        this.model = model;
        this.rokVyroby = rokVyroby;
        this.farba = farba;
    }

    void vypis(){
        System.out.println("Znacka: " + znacka + " model: " + model+ " rokVyroby: " + rokVyroby + " farba: " + farba);
    }
}

class Nakladny extends Automobil {
    int nosnost;
    int objem;
    Nakladny(String znacka, String model, int nosnost, int objem,String farba,int rokVyroby){
        super(znacka, model, rokVyroby, farba);
        this.nosnost = nosnost;
        this.objem = objem;
    }
    void vypis(){
        System.out.println("znacka: " + znacka + " model: " + model+ " rokVyroby: "+rokVyroby+" farba: "+farba+" nosnost: "+ nosnost+" objem: "+ objem);
    }
}

class Osobny extends Automobil {
    int pocetMiest;
    int pocetDveri;
    Osobny(int pocetDveri,int pocetMiest, String znacka, String model, int rokVyroby,String farba){
        super(znacka, model, rokVyroby, farba);
        this.pocetMiest = pocetMiest;
        this.pocetDveri = pocetDveri;
    }
    void vypis(){
        System.out.println("znacka: " + znacka + " model: " + model+ " rokVyroby: "+rokVyroby+" farba: "+farba+" pocetMiest: "+pocetMiest+" pocetDveri: "+pocetDveri);
    }
}
