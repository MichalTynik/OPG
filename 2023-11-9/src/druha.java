package src;

/*Napíšte metódu na výpočet priemeru troch čísel. 
Údaje testu: 
Zadajte prvé číslo: 25 
Zadajte druhé číslo: 45 
Zadajte tretie číslo: 65 
Očakávaný výstup: 
Priemerná hodnota je 45.0 */
import java.util.Scanner;
public class druha {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Zadajte prvé číslo: ");
        int a = sc.nextInt();
        System.out.print("Zadajte druhé číslo: ");
        int b = sc.nextInt();
        System.out.print("Zadajte tretie číslo: ");
        int c = sc.nextInt();
        System.out.println("Priemerná hodnota je " + (a + b + c) / 3.0);
        sc.close();
}

}
