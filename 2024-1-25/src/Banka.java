package src;

public class Banka {
    float urokMiera = 0.0f;
    public static void main(String[] args) {
        Banka s = new Slsp();
        s.urokMiera();
        s = new Vub();
        s.urokMiera();
        s = new Tatra();
        s.urokMiera();
    }
    void urokMiera() { System.out.println(urokMiera);}
    
}

 class Slsp extends Banka{
    float urokMiera = 4.5f;
    void urokMiera() { System.out.println(urokMiera);}
}

 class Vub extends Banka{
    float urokMiera = 3.2f;
    void urokMiera() { System.out.println(urokMiera);}
}

 class Tatra extends Banka{
    float urokMiera = 6.0f;
    void urokMiera() { System.out.println(urokMiera);}
}