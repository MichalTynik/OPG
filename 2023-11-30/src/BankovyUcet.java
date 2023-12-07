package src;


public class BankovyUcet {
    long cu;
    String meno;
    double peniaze;

    public BankovyUcet(long cu, String meno, double peniaze) {
        this.cu = cu;
        this.meno = meno;
        this.peniaze = peniaze;
    }

    public void naplnUcet(long cu, String meno, double peniaze) {
        this.cu = cu;
        this.meno = meno;
        this.peniaze = peniaze;
    }

    public void kontrolujZostatok() {
        System.out.println("Cislo uctu: " + cu + " Meno: " + meno + " Zostatok: " + peniaze);
    }

    public void vloz(double peniaze){
        this.peniaze += peniaze;
        System.out.println("Vlozil si "+peniaze+" zostatok je "+this.peniaze);
    }

    public void vyber(double peniaze){
        if (this.peniaze<peniaze){
            System.out.println("Nemozete vybrat "+peniaze+"$ kvoli nedostatku na ucte");
            System.out.println("Max hodnota vyberu moze byt: "+this.peniaze);
        }
        else{
            this.peniaze -= peniaze;
        System.out.println("Vyberal si "+peniaze+" zostatok je "+this.peniaze);
    
        }
    }
}

/**
 * InnerBankovyUcet
 */
class InnerBankovyUcet {
    public static void main(String[] args) {
        BankovyUcet bu = new BankovyUcet(123,"Ujo1",120);
        BankovyUcet bu1 = new BankovyUcet(345,"Ujo2",150);
        BankovyUcet bu2 = new BankovyUcet(567,"Ujo3",270);
        bu.vloz(130);
        bu1.vloz(150);
        bu2.vloz(50);
        bu.vyber(20);
        bu1.vyber(500);
        bu2.vyber(100);
        bu1.kontrolujZostatok();
        bu2.kontrolujZostatok();
        bu.kontrolujZostatok();
    }

}