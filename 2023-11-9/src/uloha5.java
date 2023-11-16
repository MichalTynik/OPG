package src;
/*Napíšte metódu na počítanie všetkých slov v reťazci.  
Testovacie údaje: 
Zadajte reťazec: Kto nevie byť spokojný s málom, nebude spokojný nikdy. 
Očakávaný výstup: 
Počet slov v reťazci: 9 */

import java.util.Scanner;

public class uloha5 {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Zadajte retazec: ");
        String veta = sc.nextLine();
        int pocet = 1;
        sc.close();
        for (int i = 0; i < veta.length(); i++) {
            if (veta.charAt(i)== ' '){
                pocet++;
            }
        }
        System.out.println("Pocet slov v retazci: "+ pocet);

    }
}
