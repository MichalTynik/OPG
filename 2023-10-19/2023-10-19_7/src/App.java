import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner sc = new Scanner(System.in);
        int ciselko = sc.nextInt();
        sc.close();
        for (int i = 1; i < 11; i++){
            System.out.println(ciselko + " * " + i + " = " + ciselko * i);
        }
        }
    }

