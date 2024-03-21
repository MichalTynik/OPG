package OPG.stk;

class PlynoveAuto extends Auto implements PlynovyPohon {
    public PlynoveAuto(String VINCislo, String Znacka, String Farba) {
        super(VINCislo, Znacka, Farba);
    }

    public void diagnostTlakuPneumatiky() { System.out.println("Tlak v pneumatikách: 2,4 MPa");
    }

    @Override
    public void meranieTlakuPlynuVZasobniku() {
        System.out.println("Meranie tlaku plynu v zásobníku: 100 bar");
    }
}