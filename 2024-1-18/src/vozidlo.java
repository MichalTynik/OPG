package src;

public class vozidlo {
    void jazdit(){
        System.out.println(" vozidlo sa pohybuje");
    }
}
 class motocykel extends vozidlo {
    void jazdit(){System.out.println(" motocykel sa pohybuje");}
    public static void main(String[] args) {
        motocykel mot = new motocykel();
        mot.jazdit();
    }
}
