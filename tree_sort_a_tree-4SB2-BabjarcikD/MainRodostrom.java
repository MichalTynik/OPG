
public class MainRodostrom {
    public static void main(String[] args) {
        Nodes babkaM = new Nodes("Babka Beta");
        Nodes dedkoM = new Nodes("Dedko Fero");
        Nodes babkaO = new Nodes("Babka Anna");
        Nodes dedkoO = new Nodes("Dedko Anton");
        Nodes mamka = new Nodes("Mamka Adriana");

        babkaM.setNext(mamka);
        dedkoM.setNext(mamka);

        Nodes osoba = new Nodes("Ocko Radovan");
        dedkoO.setNext(osoba);
        osoba = new Nodes("Mamka maja");
        babkaM.setNext(osoba);
        osoba = new Nodes("Ja Riso");
        babkaM.getNext().setNext(osoba);

        babkaM.display();
    }
}
