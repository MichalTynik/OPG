import java.util.ArrayList;
import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
    }
}

class Elektronika{
    private ArrayList<String> ele = new ArrayList<String>();
    private ArrayList<ArrayList<String>> zoznam = new ArrayList<ArrayList<String>>();
    String odpoved;
     void Elektronika() {
        OtazkaPridanie();
    }

    void Pridavanie(){
        Scanner scanner = new Scanner(System.in);
        System.out.println("Nazov: ");
        String meno = scanner.nextLine();
        System.out.println("Cena: ");
        String cena = scanner.nextLine();
        ele.add(meno);
        ele.add(cena);
        zoznam.add(ele);
    }

    void Odstranenie(){
        Scanner scanner = new Scanner(System.in);
        System.out.println("Nazov ele. ktoru chcete odstranit "+ zoznam.get(0) );
    }

    void OtazkaPridanie(){
        Scanner scanner = new Scanner(System.in);
        System.out.println("Chete zadat dalsi?[y/n]: ");
        odpoved = scanner.nextLine();
        switch (odpoved) {
            case "y":
                Pridavanie();
                break;
            case "n":
                CelkovaOtazka();
            default:
                OtazkaPridanie();
                break;
        }
    }

    void CelkovaOtazka(){
        Scanner scanner = new Scanner(System.in);
        String odpoved;
        System.out.println("[pridat, odstranit, menu]");
        odpoved = scanner.nextLine();
        switch (odpoved) {
            case "pridat":
                OtazkaPridanie();
                break;
            case "odstranit":
                break;
            default:
                CelkovaOtazka();
                break;
        }
    }
}


