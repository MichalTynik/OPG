package src;

public class Upcasting {
    public static void main(String[] args) {
        Bycikel b = new Elektorbicykel();
        System.out.println(b.rychlost);
        b.pohon();
    }
}

class Bycikel {
    int rychlost = 40;
    void pohon(){
        System.out.println("nohy");
    }
}

class Elektorbicykel extends Bycikel {
    int rychlost = 60;
    void pohon(){System.out.println("elektromotor");}
}
