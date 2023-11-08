/*Napíšte program, ktorý prečíta číslo s desatinnou čiarkou a výpiše "nula", ak 
je číslo nula. V opačnom prípade výpise „pozitívne číslo“ alebo „negatívne 
číslo“. Pridajte „malé“, ak je absolútna hodnota čísla menšia ako 1, alebo 
„veľké“, ak je väčšia 1 000 000. 
Testovacie dáta 
Zadajte číslo: 25 
 */
import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner sc = new Scanner(System.in);
        System.out.println("Zadajte číslo: ");
        double number = sc.nextDouble();
        if (number == 0) {
            System.out.println("nula");
        } else {
            if (number > 0) {
                System.out.println("pozitívne číslo");
            } else {
                System.out.println("negatívne číslo");
            }
            if (Math.abs(number) < 1) {
                System.out.println("malé");
            } else if (Math.abs(number) > 1000000) {
                System.out.println("veľké");
            }
        }
        sc.close();
    }
}
