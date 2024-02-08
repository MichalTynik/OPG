interface Tlacitelne {
    void tlacit();

    default void nic() {
        System.out.println("Ahoj default");
    }

    static int objemKocky(int x) {
        return x * x * x;
    }
}

/**
 * Zobrazitelne
 * extends Tlacitelne
 */
interface Zobrazitelne extends Tlacitelne {
    void zobrazit();
}

class Test implements Tlacitelne {
    public void tlacit() {
        System.out.println("Ahoj");
    }

    void zobrazit() {
        System.out.println("Vitaj");
    }

    public static void main(String[] args) {
        Test t = new Test();
        t.tlacit();
        t.nic();
        t.zobrazit();
        System.out.println(Tlacitelne.objemKocky(20));
    }
}