package src;

public class Uloha4 {
    public static void main(String[] args) {
        int pole[][] ={{1,2,3},{4,5,6},{7,8,9}};
        for (int[] i : pole) {
            for (int j : i) {
                System.out.print(j+" ");
            }
            System.out.println();
        }
    }
}
