/*Napíšte program na zobrazenie tabuľky násobenia daného celého čísla.  
Testovacie údaje 
Zadajte číslo pre výpočet tabuľky násobenia: 5  
Očakávaný výstup : 
5 x 0 = 0 
5 x 1 = 5 
5 x 2 = 10 
5 x 3 = 15 
5 x 4 = 20 
5 x 5 = 25 */
import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner sc = new Scanner(System.in);
        System.out.println("Zadajte číslo pre výpočet tabuľky násobenia: ");
        int number = sc.nextInt();
        for (int i = 0; i <= number; i++) {
            System.out.println(number + " x " + i + " = " + number * i);
        }
        sc.close();
    }
}
