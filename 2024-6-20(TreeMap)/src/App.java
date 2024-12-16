import java.util.*;

 class Kniha {
    int id;
    String nazov, autor, vydavatel;
    int cena;

    public Kniha(int id, String nazov, String autor, String vydavatel, int cena){
        this.id = id;
        this.nazov = nazov;
        this.autor = autor;
        this.vydavatel = vydavatel;
        this.cena = cena;
    }
    
}


public class App {
    public static void main(String[] args) throws Exception {
        Map<Integer, Kniha> kniznica = new TreeMap<Integer, Kniha>();
        Kniha k1 = new Kniha(101, "Jazyk C", "Lukas Lukasovsky","LLL", 8);
        Kniha k2  = new Kniha(102, "Jazyk B", "Lukas iny", "MMM", 10);
        Kniha k3 = new Kniha(103, "Jazyk D", "Lukas zaseiny", "ZZZ", 30);
        kniznica.put(1,k1);
        kniznica.put(2,k2); 
        kniznica.put(3,k3);

        for (Map.Entry<Integer, Kniha> polozka : kniznica.entrySet()) {
            
        }
    }
}
