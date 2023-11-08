/*Napíšte program, ktorý používateľovi poskytne jeden znak z 
abecedy. Vypíšte samohlásku alebo spoluhlásku v závislosti od vstupu 
používateľa. Ak používateľský vstup nie je písmeno (medzi a, z alebo A, Z), 
alebo ide o reťazec s dĺžkou > 1, vypíšte chybové hlásenie.  
Testovacie údaje 
Zadajte písmeno abecedy: p 
Očakávaný výstup : 
Zadané písmeno je spoluhláskové */

import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner sc = new Scanner(System.in);
        
        String[] abeceda = new String[] {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
        boolean end = true;
        System.out.print("Zadajte písmeno abecedy: ");
        String input = sc.nextLine();
        if (input.length() >1){
            System.err.println("Zadal si viac znakov");
            System.exit(0);
        }
        if (input.length() == 0){
            System.err.println("Zadal si prázdny reťazec");
            System.exit(0);
        }
        for (String string : abeceda) {
            if (string.equals(input)){
                end = false;
                break;
            }
        }
        if (input.length() == 1 && end == false){
            char c = input.charAt(0);
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'y' || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U' || c == 'Y'){
                System.out.println("Zadané písmeno je samohláskové");
            }
            else {
                System.out.println("Zadané písmeno je spoluhláskové");
            }
        sc.close();
        }
        else{
            System.out.println("Zadal si neplatné písmeno");
        }
    }
}
