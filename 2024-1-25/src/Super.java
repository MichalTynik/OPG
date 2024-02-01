package src;

public class Super {
    public static void main(String[] args) {
        Pes p = new Pes();
        p.vypisFarba();
        p.zije();
    }
}

class Zviera{
    String farba = "farba";
    void zerie(){System.out.println("zerie");}
}

 class Pes extends Zviera{
    String farba = "farbaPes";
    void zerie(){System.out.println("zerie meso");}
    void steka(){System.out.println("steka");}
    void zije(){
        super.zerie();
        steka();
    }
    void vypisFarba() {
        System.out.println(farba);
        System.out.println(super.farba);
    }
}
