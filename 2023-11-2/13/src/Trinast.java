/*Napíšte program, ktorý zobrazí 3 mocninu (kocku) čísla až po zadané 
koncové celé číslo. 
Testovacie údaje 
Zadaj koncové celé číslo : 4 
Očakávaný výstup : 
Číslo je: 1 a kocka 1 je: 1  
Počet je: 2 a kocka 2 je: 8  
Počet je 3 a kocka 3 je 27  
Číslo je 4 a kocka 4 je 64  */
import java.util.Scanner;

public class Trinast {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Zadaj koncové celé číslo: ");
        int n = sc.nextInt();
        for (int i = 1; i <= n; i++) {
            System.out.println("Číslo je: " + i + " a kocka " + i + " je: " + (int) Math.pow(i, 3));
        }
        sc.close();
    }
}
