import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner sc = new Scanner(System.in);

        System.out.print("Zadaj cislo: ");
        int vstup = sc.nextInt();
        if (vstup>0)
            System.out.println("Vstup je kladne");
        else if (vstup<0)
            System.out.println("Vstup je zaporne");
        else
            System.out.println("Vstup je nula");
        sc.close();
        }
}
