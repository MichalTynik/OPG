/*Napíšte program, ktorý načíta dve čísla s desatinnou čiarkou a otestuje, či 
sú rovnaké až na tri desatinné miesta.  
Testovacie údaje 
Zadaj 1. číslo: 25.586 
Zadaj 2. číslo: 25.589 
Očakávaný výstup : 
Sú odlišné */

import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner sc = new Scanner(System.in);

        System.out.println("Zadaj 1. číslo: ");
        double cislo1 = sc.nextDouble();
        System.out.println("Zadaj 2. číslo: ");
        double cislo2 = sc.nextDouble();
        sc.close();
        if (cislo1 == cislo2){
            System.out.println("Sú rovnaké");
        }
        else{
            System.out.println("Sú odlišné");
        }
        
    }
}
