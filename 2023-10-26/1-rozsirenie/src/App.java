/*Program by sa dal rozšíriť o funkciu, ktorá by počítala celkovú úrodu na farme. Táto funkcia by sa dala implementovať nasledovne:
Očakávaný výstup:
Počet plodín: 50
Typ plodiny: ovocie
Úroda na jednu plodinu: 75.50 kg
Celková úroda: 3775 kg */

import java.util.Random;
import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner sc = new Scanner(System.in);
        String vybrane = "";
        Random rn = new Random();
        int plodiny = rn.nextInt(100)+1;
        String[] typ = new String[]{"ovocie","zelenina","obilnina"};
        
        for (int i = 0; i<typ.length; i++)
        {
            
            
            System.out.println("Chces pestovat : "+typ[i]+" [Y/N]");
            if (sc.nextLine().equals("Y"))
            {
                vybrane = typ[i];
                break;
            }
            
        }
        sc.close();
        int uroda = rn.nextInt(100);
        if (vybrane.isEmpty()){
            System.out.println("Nevybral si si ziadnu plodinu!");
        }
        else {
            System.out.println("Počet plodín: "+plodiny);
        System.out.println("Typ plodiny: "+ vybrane);
        System.out.println("Úroda na jednu plodinu: "+uroda+" kg");
        System.out.println("Celková úroda: "+uroda*plodiny+" kg");
        }
    }
}
