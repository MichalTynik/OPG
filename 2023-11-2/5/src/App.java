/*Napíšte program, ktorý načíta číslo od používateľa a vygeneruje celé číslo 
medzi 1 a 7 a zobrazí názov dňa v týždni. 
Testovacie údaje 
Vstupné číslo: 3 
Očakávaný výstup : 
Streda */

import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner sc = new Scanner(System.in);
        String[] dni = new String[] {"Pondelok", "Utorok", "Streda", "Stvrtok", "Piatok", "Sobota", "Nedela"};

        System.out.println("Zadaj číslo: ");
        int number = sc.nextInt();
        sc.close();
        if (number > 7 || number < 1){
            System.out.println("Zadal si nespravne cislo");
            return;
        }
        System.out.println(dni[number - 1]);
        
    }
}
