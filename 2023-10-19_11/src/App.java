import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner sc = new Scanner(System.in);
        float a = sc.nextFloat();
        double obvod = Math.PI * 2 * a;
        double obsah = Math.PI * a * a;
        System.out.println("Obvod kruhu je: " + obvod);
        System.out.println("Obsah kruhu je: " + obsah);
        sc.close();
    }
}
