package src;

interface Tlacenie {
    void tlacit();
}

class A4 implements Tlacenie{
    public void tlacit(){System.out.println("Ahoj");}
    public static void main(String[] args) {
        A4 vykres = new A4();
        vykres.tlacit();   
    }
}
