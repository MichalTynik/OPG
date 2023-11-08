/*Napíšte program na zobrazenie prvých 10 prirodzených čísel.  
Očakávaný výstup : 
Prvých 10 prirodzených čísel je:                                                 
                                                                                  
1                                                                                 
2                                                                                 
3                                                                                 
4                                                                                 
5                                                                                 
6                                                                                 
7                                                                                 
8                                                                                 
9                                                                                 
10 */

public class App {
    public static void main(String[] args) throws Exception {
        System.out.println("Prvých 10 prirodzených čísel je: ");
        System.out.println();
        for (int i = 1; i <= 10; i++) {
            System.out.println(i);
        }
    }
}
