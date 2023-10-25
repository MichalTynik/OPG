import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner sc = new Scanner(System.in);
        Float[] a = new Float[]{0f,0f,0f};
        for (int i = 0; i < 3;i++){
            a[i] = sc.nextFloat();
        }
        sc.close();
        System.out.println((a[0] + a[1] + a[2]) / a.length );
    }
}
