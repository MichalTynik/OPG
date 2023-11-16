package src;

/**
 * Inneruloha1Upravena
 */
public class Inneruloha1Upravena {
    static void parneNeparneStatic(int cislo){
        if(cislo %2 == 0){
            System.out.println(cislo + " je parne");
        }
        else{
            System.out.println(cislo + " je neparne");
        }
    }

    void parneNeparneNonStatic(int cislo){
        if(cislo %2 == 0){
            System.out.println(cislo + " je parne");
        }
        else{
            System.out.println(cislo + " je neparne");
        }
    }
}