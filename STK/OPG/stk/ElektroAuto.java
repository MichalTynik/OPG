package OPG.stk;

public class ElektroAuto extends Auto implements ElektrickyPohon {
    public ElektroAuto(String VINCislo, String Znacka, String Farba) {
        super(VINCislo, Znacka, Farba);
    }

    @Override
    public void diagnostikaTlakuBrzdovejKvapaliny() {
        System.out.println("Tlak brzdovej kvapaliny: 18 MPa");
    }

    @Override
    public void diagnostikaTlakuPneumatiky() {
        System.out.println("Tlak v pneumatikách: 2.9 MPa");
    }

    @Override
    public void meranieNapatiaAkumulatora() {
        System.out.println("Napätie akumulatorov: 200 V");
    }
}
