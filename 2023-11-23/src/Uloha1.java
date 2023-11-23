package src;

public class Uloha1 {
    public static void main(String[] args) {
        int c[];
        c = new int[5];
        int[] a = new int[5];
        int b = 10;
        for (int i = 0; i < a.length; i++) {
            a[i] = b;
            c[i] = b;
            b=b+10;
        }
        for (int i = 0; i < a.length;i++) {
            System.out.println(a[i]);
        }
        System.out.println("--------------------------------------------------------");
        for (int i : c) {
            System.out.println(i);
        }
    }
}