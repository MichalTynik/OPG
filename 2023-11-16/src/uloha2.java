package src;

public class uloha2 {
    public static void main(String[] args) {
        uloha2Metody metody = new uloha2Metody();
        uloha2Metody metody2 = new uloha2Metody();
        uloha2Metody metody3 = new uloha2Metody();
        metody.setMeno("Michal");
        metody2.setMeno("Juro");
        metody3.setMeno("Jakub");
        metody.setID(1);
        metody2.setID(2);
        metody3.setID(3);
        metody.zobrazi2(metody.getID(), metody.getMeno());
        metody2.zobrazi2(metody2.getID(), metody2.getMeno());
        metody3.zobrazi2(metody3.getID(), metody3.getMeno());
    }
}