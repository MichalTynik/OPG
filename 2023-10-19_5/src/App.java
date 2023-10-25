import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner scanner = new Scanner(System.in);
        int ciselko1 = scanner.nextInt();
        int ciselko2 = scanner.nextInt();
        System.out.println(ciselko1*ciselko2);
        scanner.close();
    }
}
