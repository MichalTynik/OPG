/*Napíšte program na zobrazenie n členov nepárneho prirodzeného čísla a 
ich súčtu.  
Zadaj nepárne prirodzené číslo 5 
Očakávaný výstup : 
Nepárne čísla sú: 
1  
3  
5  
7  
9  
Súčet nepárnych prirodzených čísel až do 5 je: 25 */
import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner sc = new Scanner(System.in);
        System.out.println("Zadaj nepárne prirodzené číslo: ");
        int n = sc.nextInt();
        int sum = 0;
        System.out.println("Nepárne čísla sú: ");
        for (int i = 1; i <= n*2; i = i + 2) {
            System.out.println(i);
            sum = sum + i;
        }
        System.out.println("Súčet nepárnych prirodzených čísel až do " + n + " je: " + sum);
        sc.close();
    }
}
