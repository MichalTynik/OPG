package src;

public class Uloha2 {
    public static void main(String[] args) {
        int a[] = {1, 2, 3, 4, 5};
        min(a);
    }

    static void min(int pole[]){
        int min = pole[0];
        for (int i = 1; i < pole.length; i++) {
            if (min > pole[i])
                min = pole[i];
        }
        System.out.println(min);
    }
}
