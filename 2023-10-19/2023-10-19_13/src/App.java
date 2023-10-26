import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner sc = new Scanner(System.in);
        float sirka = sc.nextFloat();
        float vyska = sc.nextFloat();
        float obvod = 2 * (sirka + vyska);
        float obsah = sirka * vyska;
        System.out.println("Povrch je "+ sirka + " * " + vyska + " = " + obsah);
        System.out.println("Obvod je " + "2 * (" + sirka + " + " + vyska + ") = " + obvod);
        sc.close();
    }
}
