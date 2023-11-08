/*Napíšte program, ktorý zo zadaných 5 čísel z klávesnice nájde ich súčet a 
priemer. 
Testovacie údaje 
Zadajte 5 čísel: 1 2 3 4 5 
Očakávaný výstup : 
Zadané 5 čísla: 
1 
2 
3 
4 
5 
Súčet 5 je: 15 
Priemer je: 3.0 */

import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner sc = new Scanner(System.in);
        System.out.print("Zadajte 5 čísel: ");
        int[] cisla = new int[5];
        for (int i = 0; i < 5; i++) {
            cisla[i] = sc.nextInt();
        }
        int sucet = 0;
        for (int i = 0; i < 5; i++) {
            sucet += cisla[i];
        }
        System.out.println("Zadané 5 čísla: ");
        for (int i = 0; i < 5; i++) {
            System.out.println(cisla[i]);
        }
        System.out.println("Súčet 5 je: " + sucet);
        System.out.println("Priemer je: " + (double) sucet / 5);
        sc.close();
    }
}
