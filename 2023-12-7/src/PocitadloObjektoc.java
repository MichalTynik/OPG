package src;

public class PocitadloObjektoc {
    static int pocitadlo = 0;
    public PocitadloObjektoc(){
        pocitadlo++;
    }

    public int getPocitadlo(){
        return pocitadlo;
    }
}

class uloha {
    public static void main(String[] args) {
        PocitadloObjektoc pocitadloObjektoc = new PocitadloObjektoc();
        System.out.println(pocitadloObjektoc.getPocitadlo());
        PocitadloObjektoc pocitadloObjektoc2 = new PocitadloObjektoc();
        System.out.println(pocitadloObjektoc2.getPocitadlo());
    }
}
