package src;

class Operacia {
    int umocnenie(int n){
        return n*n;
    }
}

class Kruh {
    Operacia op;
    double pi = 3.14;
    double obsah(int polomer){
        op = new Operacia();
        int mocnina = op.umocnenie(polomer);
        return pi*mocnina;
    }
    public static void main(String[] args) {
        Kruh k = new Kruh();
        double vysledok = k.obsah(5);
        System.out.println(vysledok);
    }
}
