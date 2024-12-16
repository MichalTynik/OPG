import java.util.*;

class Kniha {
    int id;
    String meno, autor, vydavatel;
    int cena;

    Kniha(int id, String meno, String autor, String vydavatel, int cena) {
        this.id = id;
        this.meno = meno;
        this.autor = autor;
        this.vydavatel = vydavatel;
        this.cena = cena;
    }
}

public class ArrayListPriklad {
    public static void main(String[] args) {
        List<Kniha> kniznica = new ArrayList<Kniha>();

        Kniha k1 = new Kniha(101, "Jayzk C", "Peter Petrovsky", "PPP", 88);
        Kniha k2 = new Kniha(102, "Jayzk Java", "Marek Krenovsky", "MM", 44);
        Kniha k3 = new Kniha(103, "Jayzk Python 3", "Lukáš Lukášovský", "LL", 60);

        kniznica.add(k1);
        kniznica.add(k2);
        kniznica.add(k3);

        for (Kniha k : kniznica) {
            System.out.println(k.id + ", " + k.meno + ", " + k.autor + ", " + k.vydavatel + ", " + k.cena);
        }
    }
}