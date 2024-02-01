package src;

public interface Vykreslite {
    void kreslit();
}

class Obdlznik implements Vykreslite {
    public void kreslit() {System.out.println("Obdlznik");}
}

class Kruh implements Vykreslite {
    public void kreslit() {System.out.println("Kruh");}
}

class Test{
    public static void main(String[] args) {
        Vykreslite vykres = new Kruh();
        vykres.kreslit();
    }
}
