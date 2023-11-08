/*Napíšte program na riešenie kvadratických rovníc (použite if, else if a else).  
Pomôcka: 𝑥1,2 =−𝑏±√𝐷
2𝑎 ; 𝐷 =𝑏2 −4𝑎𝑐 
Vstup testovacích údajov 
Vstup a: 1 
Vstup b: 5 
Vstup c: 1 
Očakávaný výstup : 
Korene sú -0,20871215252208009 a -4,7912878474779195 */

import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner sc = new Scanner(System.in);

        System.out.println("Zadaj a: ");
        double a = sc.nextDouble();
        System.out.println("Zadaj b: ");
        double b = sc.nextDouble();
        System.out.println("Zadaj c: ");
        double c = sc.nextDouble();
        double d = b * b - 4 * a * c;
        if (d > 0) {
            double x1 = (-b + Math.sqrt(d)) / (2 * a);
            double x2 = (-b - Math.sqrt(d)) / (2 * a);
            System.out.println("Korene su " + x1 + " a " + x2);
        } else if (d == 0) {
            double x = -b / (2 * a);
            System.out.println("Koren je " + x);
        } else {
            System.out.println("Rovnica nema riesenie");
        }
        sc.close();
    }
}
