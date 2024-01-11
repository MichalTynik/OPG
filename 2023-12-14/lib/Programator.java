package lib;
class Zamestnanec {
    float vyplata = 1100;
}

/**
 * Programator
 */
class Programator extends Zamestnanec{
    int bonus = 300;
    public static void main(String[] args) {
        Programator p = new Programator();
        System.out.println("Vyplata programatora je:"+ p.vyplata);
        System.out.println("Bonus programatora je:"+ p.bonus);
    }
    
}
