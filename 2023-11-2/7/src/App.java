/*Napíšte program na zistenie počtu dní v mesiaci.  
Testovacie dáta 
Zadaj číslo mesiaca: 2 
Zadaj rok: 2022 
Očakávaný výstup : 
Február 2022 má 29 dní */

import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner sc = new Scanner(System.in);

        String[] mesiace = new String[] {"Januar", "Februar", "Marec", "April", "Maj", "Jun", "Jul", "August", "September", "Oktober", "November", "December"};
        System.out.println("Zadaj číslo mesiaca: ");
        int mesiac = sc.nextInt();
        System.out.println("Zadaj rok: ");
        int rok = sc.nextInt();
        int pocetDni = 0;
        switch (mesiac) {
            case 1:
                pocetDni = 31;
                break;
            case 3:
                pocetDni = 31;
                break;
            case 5:
                pocetDni = 31;
                break;
            case 7:
                pocetDni = 31;
                break;
            case 8:
                pocetDni = 31;
                break;
            case 10:
                pocetDni = 31;
                break;
            case 12:
                pocetDni = 31;
                break;
            case 4:
                pocetDni = 30;
                break;
            case 6:
                pocetDni = 30;
                break;
            case 9:
                pocetDni = 30;
                break;
            case 11:
                pocetDni = 30;
                break;
            case 2:
                if ((rok % 4 == 0 && rok % 100 != 0) || rok % 400 == 0) {
                    pocetDni = 28;
                } else {
                    pocetDni = 29;
                }
                break;
            default:
                System.out.println("Neplatný mesiac");
                break;
        }
        System.out.println(mesiace[mesiac -1] + " " + rok + " má " + pocetDni + " dní");
        sc.close();
    }
}
