package src;

public class scitacka {
    static int scitanie(int a, int b){return a+b;}
    static int scitanie(int a, int b, int c){return a+b+c;}
}

 class TestPretazenia {
    public static void main(String[] args) {
        System.out.println(scitacka.scitanie(2, 3));
        System.out.println(scitacka.scitanie(3,4,5));
    }
    
}
