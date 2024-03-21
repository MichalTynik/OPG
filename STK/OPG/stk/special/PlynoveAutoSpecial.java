package OPG.stk.special;

import OPG.stk.PlynovyPohon;
import OPG.stk.Auto;

class PlynoveAutoSpecial extends Auto implements PlynovyPohon {
    public PlynoveAutoSpecial(String VINCislo, String Znacka, String Farba) {
        super(VINCislo, Znacka, Farba);
    }

    @Override
    public void meranieTlakuPlynuVZasobniku() {
        System.out.println("Tlak v plynovom zásobníku: 100 bar");
    }
}