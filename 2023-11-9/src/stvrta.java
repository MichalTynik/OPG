package src;

/*Napíšte metódu na počítanie všetkých samohlások v reťazci. 
Testovacie údaje: 
Zadajte reťazec: Odvaha 
Očakávaný výstup: 
Počet samohlások v reťazci: 3 */
import java.util.Scanner;
public class stvrta {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Zadajte reťazec: ");
        String retazec = sc.nextLine();
        int pocet = 0;
        for (int i = 0; i < retazec.length(); i++) {
            if (retazec.charAt(i) == 'a' || retazec.charAt(i) == 'e' || retazec.charAt(i) == 'i' || retazec.charAt(i) == 'o' || retazec.charAt(i) == 'u' || retazec.charAt(i) == 'A' || retazec.charAt(i) == 'E' || retazec.charAt(i) == 'I' || retazec.charAt(i) == 'O' || retazec.charAt(i) == 'U') {
                pocet++;
            }
        }
        sc.close();
        System.out.println("Počet samohlások v reťazci: " + pocet);
    }
}
