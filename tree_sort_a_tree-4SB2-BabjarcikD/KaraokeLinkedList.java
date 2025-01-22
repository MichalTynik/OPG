import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Random;
import java.util.Scanner;

public class KaraokeLinkedList {
    public static void main(String[] args) {
        LinkedList<String> lyricsList = new LinkedList<>();
        Random random = new Random();
        List<String> list = new ArrayList<>();

        // Načítanie textu zo súboru do LinkedList
        try (BufferedReader reader = new BufferedReader(new FileReader("textik.txt"))) {
            String line;
            while ((line = reader.readLine()) != null) {
                for (String word : line.strip().split("\\s+")) {
                    list.add(word);
                }
            }
        } catch (IOException e) {
            System.out.println("Chyba pri načítaní súboru: " + e.getMessage());
            return;
        }

        // Interakcia s používateľom
        System.out.println("Stlač ENTER pre vypísanie slova, alebo napíš '-' pre vypísanie zoznamu:");
        Scanner scanner = new Scanner(System.in);

        while (true) {
            String input = scanner.nextLine();
            
            if (list.isEmpty() && lyricsList.isEmpty()) {
                System.out.print("Koniec skladby");
                break;
            }

            if (input.isEmpty()) {
                int ran = random.nextInt(2);
                if (ran == 0) {
                    if (!lyricsList.isEmpty()) {
                        String word = lyricsList.removeFirst();
                        System.out.print("Textík: " + word);
                    } else {
                        System.out.print("NO DATA");
                    }
                } else if (ran == 1) {
                    if (!list.isEmpty()) {
                        String word = list.removeFirst();
                        lyricsList.add(word);
                    }
                }
            } else if (input.equals("-")) {
                if (lyricsList.isEmpty()) {
                    System.out.println("Zoznam je prázdny.");
                } else {
                    System.out.println("Zoznam: " + lyricsList);
                }
            } else {
                System.out.println("Neplatný vstup. Stlač ENTER alebo napíš '-'.");
            }
        }
    }
}
