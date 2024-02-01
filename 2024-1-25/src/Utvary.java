package src;

import java.util.Scanner;
public class Utvary {
    public static void main(String[] args) {
        
        Scanner scanner = new Scanner(System.in);
        System.out.print("Utvary (obdlznik, trojuholnik, kruh): ");
        String str = scanner.nextLine();
        switch (str) {
            case "obdlznik":
                Utvary u = new Obdlznik();    
                u.vykresli();
                break;
            case "trojuholnik":
                u = new Trojuholnik();
                u.vykresli();
                break;
            case "kruh":
                u = new Kruh();
                u.vykresli();
                break;
        }
        scanner.close();
    }
    void vykresli(){
        System.out.println("Utvar");
    }
}

class Obdlznik extends Utvary{
    void vykresli(){
        System.out.println("Obdlznik");
    }
}

class Trojuholnik extends Utvary{
    void vykresli(){
        System.out.println("Trojuholnik");
    }
}

class Kruh extends Utvary{
    void vykresli(){
        System.out.println("Kruh");
    }
}