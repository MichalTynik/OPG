import java.util.*;

public class App {
    public static void main(String[] args) throws Exception {
        ArrayList<String> list = new ArrayList<String>();
        list.add("Volvo");
        list.add("BMW");
        list.add("Ford");
        list.add("Mazda");
        
        Iterator itr = list.iterator();
        while (itr.hasNext()) {
            System.out.println(itr.next());
        }
        ArrayList<Integer> cisla = new ArrayList<Integer>();
        for (int i = 0; i < 6; i++) {
            cisla.add(i);
        }
        Collections.sort(cisla);
        itr = cisla.iterator();
        while (itr.hasNext()) {
            System.out.println(itr.next());
        }
    }
}
