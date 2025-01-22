import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class TestTreeSort {
    public static void main(String[] args) {
        TreeSort myTree;
        Random random = new Random();

        System.out.println("Zadaj veľkosť zoznamu:");
        int n = new java.util.Scanner(System.in).nextInt();

        System.out.println("Vyber typ generovania: random [1], random up [2], random down [3]:");
        int m = new java.util.Scanner(System.in).nextInt();

        for (int i = 0; i < 11; i++) {
            List<Integer> list = generateList(m, n, random);
            System.out.println("## " + (i + 1) + " ##");

            myTree = new TreeSort();

            long startTime = System.nanoTime();
            for (int num : list) {
                myTree.insert(num);
            }

            String sortedResult = myTree.getTreeSort();
            long endTime = System.nanoTime();

            // Accessing stepCounter directly since getter is not defined
            System.out.println("TreeSort trval: " + ((endTime - startTime) / 1000000) + " milisekund");
            System.out.println("Počet krokov (stepCounter): " + myTree.stepCounter);
            System.out.println("----");
        }
    }

    private static List<Integer> generateList(int type, int size, Random random) {
        List<Integer> list = new ArrayList<>();
        int number;

        switch (type) {
            case 1: // Random
                for (int i = 0; i < size; i++) {
                    list.add(random.nextInt(size));
                }
                break;

            case 2: // Random up
                number = 100;
                for (int i = 0; i < size; i++) {
                    number += random.nextInt(21) - 10;
                    list.add(number);
                }
                break;

            case 3: // Random down
                number = size;
                for (int i = 0; i < size; i++) {
                    number += random.nextInt(19) - 9;
                    list.add(number);
                }
                break;
        }
        return list;
    }
}
