package OPG.stk;

class BenzinoveAuto extends Auto implements BenzinovyPohon {
    public BenzinoveAuto(String VINCislo, String Znacka, String Farba) {
        super(VINCislo, Znacka, Farba);
    }

    @Override
    public void diagnostikaTlakuBrzdovejKvapaliny() { System.out.println("Tlak brzdovej kvapaliny: 15.5 MPa");
    }

    @Override
    public void diagnostikaTlakuPneumatiky() { System.out.println("Tlak v pneumatikách: 2,7 MPa");
    }

    @Override
    public void meranieTlakuPaliva() {
        System.out.println("Tlak paliva: 10 MPa");
    }

    @Override
    public void meranieTlakuOleja() {
        System.out.println("Tlak oleja: 2 Bar");
    }

    @Override
    public void meranieTeplotyMotora() {
        System.out.println("Teplota motora: 100 °C");
    }

}
