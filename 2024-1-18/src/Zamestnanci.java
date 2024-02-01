package src;

public class Zamestnanci {
    public static void main(String[] args) {
        zamestnanec zm = new zamestnanec(1,"Juro","Kosice","Slovensko","EuroAzia");
        zamestnanec zm2 = new zamestnanec(2,"Michal","Kosice","Slovesko","EuroAzia");
        zm.zobrazit();
        zm2.zobrazit();
    }
}

 class zamestnanec{
    int id;
    String name;
    adresa as;
    zamestnanec(int id, String name, String mesto, String stat, String kontinent){
        this.id = id;
        this.name = name;
        as = new adresa(mesto, stat, kontinent);
    }
    void zobrazit(){
        System.out.println(id +" "+ name +" "+ as.mesto +" "+ as.stat+" "+ as.kontinent);
    }
}

 class adresa {
    String mesto;
    String stat;
    String kontinent;
    adresa(String mesto, String stat, String kontinent){
        this.mesto = mesto;
        this.stat =stat;
        this.kontinent = kontinent;
    }
}