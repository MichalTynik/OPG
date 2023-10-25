import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner sc = new Scanner(System.in);
        int ciselko1 = sc.nextInt();
        int ciselko2 = sc.nextInt();
        sc.close();
        System.out.println(ciselko1 + ciselko2);
        System.out.println(ciselko1 - ciselko2);
        System.out.println(ciselko1 * ciselko2);
        System.out.println(ciselko1 / ciselko2);
        System.out.println(ciselko1 % ciselko2);
    }
}
