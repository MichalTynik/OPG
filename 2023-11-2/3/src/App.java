/*Vezmite od používateľa tri čísla a vypíšte najväčšie číslo.  
Testovacie údaje 
Zadajte 1. číslo: 25 
Zadajte 2. číslo: 78 
Zadajte 3. číslo: 87 
Očakávaný výstup : 
Najväčšie číslo: 87 */

import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner sc = new Scanner(System.in);
        System.out.println("Zadajte 1. číslo: ");
        int a = sc.nextInt();
        System.out.println("Zadajte 2. číslo: ");
        int b = sc.nextInt();
        System.out.println("Zadajte 3. číslo: ");
        int c = sc.nextInt();
        if (a > b && a > c) {
            System.out.println("Najväčšie číslo: " + a);
        } else if (b > a && b > c) {
            System.out.println("Najväčšie číslo: " + b);
        } else {
            System.out.println("Najväčšie číslo: " + c);
        }
        sc.close();
    }
}
