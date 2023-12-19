public class TestDedenia {
    public static void main(String[] args) {
        NemeckyOvciak nem = new NemeckyOvciak(); //multilevel inheritance
        nem.zrat();
        nem.steka();
        nem.strazi();  
        Macka m = new Macka(); //hierarchical inheritance
        m.zrat();
        m.mnauka();
    }
}

class Zviera {
    void zrat(){System.out.println("Zerie meso");}
}

class Pes extends Zviera {
    void steka(){System.out.println("Steka na ludi");}
}

class NemeckyOvciak extends Pes {
    void strazi(){System.out.println("Strazi dom");}
}

 class Macka extends Zviera {
    void mnauka(){System.out.println("Mnauci");}
}