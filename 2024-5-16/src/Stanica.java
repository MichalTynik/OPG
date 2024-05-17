import java.util.ArrayList;

class Vlaky {
    String meno;
    int vagony;
    Vlaky(String meno, int vagony){
        this.meno = meno;
        this.vagony = vagony;
    }
}

public class Stanica{
    ArrayList<Vlaky> vlaky = new ArrayList<Vlaky>();

    void pridaj(){
        vlaky.add(new Vlaky("ER",5));
        vlaky.add(new Vlaky("IP",10));
        vlaky.add(new Vlaky("DI",7));
    }

    void odstran(String str){
        for (Vlaky vlaky2 : vlaky) {
            if (vlaky2.meno.equals(str)) {
                int index = vlaky.indexOf(vlaky2);
                vlaky.remove(index);
            }
        }
    }

    void vypis(){
        for (Vlaky vlaky2 : vlaky) {
            System.out.println(vlaky2.meno+" "+String.valueOf(vlaky2.vagony));
        }
    }

    public static void main(String[] args) {
        Stanica s = new Stanica();
        s.pridaj();
        s.odstran("DI");
        s.vypis();
    }
}
