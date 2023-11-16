package src;
/*Napíšte metódu na nájdenie najmenšieho čísla medzi tromi číslami.   
Údaje testu: 
Zadajte prvé číslo: 25 
Zadajte druhé číslo: 37 
Zadajte tretie číslo: 29 
Očakávaný výstup: 
Najmenšia hodnota je 25.0 */

import java.util.Scanner;

public class prva {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Zadajte prvé číslo: ");
        double a = sc.nextDouble();
        System.out.print("Zadajte druhé číslo: ");
        double b = sc.nextDouble();
        System.out.print("Zadajte tretie číslo: ");
        double c = sc.nextDouble();
        double min = a;
        if (b < min) {
         System.out.println("Najmenšia hodnota je " + b);
        }
        if (c < min) {
         System.out.println("Najmenšia hodnota je " + c);
        }
        else {
         System.out.println("Najmenšia hodnota je " + min);
        }
        sc.close();
    }
}
