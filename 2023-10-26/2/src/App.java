/*Zadanie 2 - hotelierstvo (základy, údajové typy)
Napíšte program v jazyku Java, ktorý bude simulovať rezerváciu izby v hoteli. Program by mal spĺňať nasledujúce požiadavky:
Užívateľ by mal byť schopný zadať údaje o rezervácii, vrátane typu izby, počtu izieb, dátumu príchodu a odchodu a počtu osôb.
Program by mal vypočítať celkovú cenu rezervácie.
Program by mal vytlačiť potvrdenie rezervácie.
 
Výstup:
Typ izby: jednolôžková
Počet izieb: 1
Dátum príchodu: 2023-10-12
Dátum odchodu: 2023-10-14
Počet osôb: 1
Celková cena: 150*/

import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner sc = new Scanner(System.in);

        System.out.println("----------------------------------------------------------------");
        System.out.println("Typ izby: ");
        String typ = sc.nextLine();
        System.out.println("Počet izieb: ");
        int pocet = sc.nextInt();
        System.out.println("Dátum príchodu: ");
        String datumP = sc.next();
        System.out.println("Dátum odchodu: ");
        String datumO = sc.next();
        System.out.println("Počet osôb: ");
        int pocetOsob = sc.nextInt();
        int cena = 0;
        if (typ.equals("jednolozkova")) {
            cena = 100;
        } else if (typ.equals("dvojlozkova")) {
            cena = 150;
        } else if (typ.equals("trojlozkova")) {
            cena = 200;
        }
        int cenaCelkova = cena * pocet * pocetOsob;
        System.out.println("Typ izby: " + typ + "\nPočet izieb: " + pocet + "\nDátum príchodu: " + datumP + "\nDátum odchodu: "+ datumO);
        System.out.println("Celková cena: " + cenaCelkova);
    sc.close();
    }
}
