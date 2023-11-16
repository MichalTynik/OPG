package src;

/*Napíšte metódu na zobrazenie stredného znaku reťazca. 
Poznámka:  
a) Ak je dĺžka reťazca nepárna, bude tam jeden stredný znak.  
b) Ak je dĺžka reťazca párna, budú tam dva stredné znaky. 
Testovacie údaje: 
Zadajte reťazec: 350 
Očakávaný výstup: 
Stredný znak v reťazci: 5 */
import java.util.Scanner;
public class tretia {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Zadajte reťazec: ");
        String s = sc.nextLine();
        if (s.length() % 2 == 0) {
            System.out.println("Stredný znak v reťazci: " + s.charAt(s.length() / 2 - 1) + s.charAt(s.length() / 2));
        }
        else {
            System.out.println("Stredný znak v reťazci: " + s.charAt(s.length() / 2));
        }

        sc.close();
    }
}
