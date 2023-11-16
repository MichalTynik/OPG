package src;

import java.util.Scanner;
public class uloha1Upravena {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Chces spustit static metodu alebo non-static metodu? [static/non-static]: ");
        String vstup = sc.nextLine();
        System.out.print("Vloz cislo: ");
        int ciselko = sc.nextInt();
        sc.close();
        if (vstup.equals("static")){
            Inneruloha1Upravena.parneNeparneStatic(ciselko);
        }
        else if (vstup.equals("non-static")){
            Inneruloha1Upravena nonstatic = new Inneruloha1Upravena();
            nonstatic.parneNeparneNonStatic(ciselko);
        }
    }
}
