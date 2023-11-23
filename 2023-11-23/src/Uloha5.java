package src;

public class Uloha5 {
    public static void main(String[] args) {
        char[] buf = {'a', 'b', 'c', 'd', 'e'};
        char[] str = new char[5];
        System.arraycopy(buf, 0, str, 0, 5);
        System.out.println(String.valueOf(str));
    }
}
