/*Napíšte program v jazyku Java, ktorý bude generovať náhodné údaje o úrode na farme. Program by mal generovať nasledujúce údaje:
Počet plodín: od 1 do 100
Typ plodiny: ovocie, zelenina alebo obilnina
Úroda na jednu plodinu: od 0 do 100 kg
 
Očakávaný výstup:
Počet plodín: 50
Typ plodiny: ovocie
Úroda na jednu plodinu: 75.50 kg
 
Možné pod úlohy a rozšírenia:
Program by sa dal rozšíriť o nasledujúce funkcie:
Možnosti generovania: Program by mohol ponúkať možnosti na výber typu plodiny a rozsahu úrody.
Správa chýb: Program by mal byť vybavený mechanizmom na správu chýb, napríklad ak sa vygeneruje počet plodín mimo rozsahu.
Grafické rozhranie: Program by mohol byť vybavený grafický rozhraním, ktoré by uľahčilo používanie */

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
        }
        
    }
}
