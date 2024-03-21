package OPG.stk;

class HybridneAuto extends Auto implements HybridnyPohon {
    public HybridneAuto(String VINCislo, String Znacka, String Farba) {
        super(VINCislo, Znacka, Farba);
    }

    @Override
    public void diagnostikaTlakuBrzdovejKvapaliny() { System.out.println("Tlak brzdovej kvapaliny: 13.5 MPa");
    }

    @Override
    public void diagnostikaTlakuPneumatiky() { System.out.println("Tlak v pneumatikách: 2,9 MPa");
    }

    @Override
    public void meranieTlakuOleja() { System.out.println("Tlak paliva: 15 MPa");
    }

    @Override
    public void meranieTlakuPaliva() { System.out.println("Tlak oleja: 3 Bar");
    }

    public void meranieTeplotyAkumulatorov() {
        System.out.println("Teplota akumulátorov: 45 °C");
    }

    public void meranieNapatiaAkumulatora() {
        System.out.println("Napätie akumulatorov: 150 V");
    }

    public void meranieTeplotyMotora() {
        System.out.println("Teplota motora je: 90 °C");
    }
}