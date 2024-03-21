package OPG.stk;

public class Auto {
    private boolean asr;
    private boolean abs;
    private boolean airBag;

    private final String vinCislo;
    private final String znacka;
    private final String farba;

    public Auto(String vinCislo, String znacka, String farba) {
        this.vinCislo = vinCislo;
        this.znacka = znacka;
        this.farba = farba;
    }
    public boolean asr() {
        return asr;
    }

    public boolean abs() {
        return abs;
    }

    public boolean airBag() {
        return airBag;
    }

    protected void setAsr(boolean asr) {
        this.asr = asr;
    }

    protected void setAbs(boolean abs) {
        this.abs = abs;
    }
    public String getVinCislo() {
        return vinCislo;
    }

    public String getZnacka() {
        return znacka;
    }

    public String getFarba() {
        return farba;
    }
    protected void setAirBag(boolean airBag) {
        this.airBag = airBag;
    }

    public void diagnostikaTlakuPneumatiky() {
        System.out.println("Tlak v pneumatikách: 2.2 Bar");
    }

    public void diagnostikaTlakuBrzdovejKvapaliny() {
        System.out.println("Tlak brzdovej kvapaliny: 12 MPa");
    }


    public void diagnostikaBezpecnostnehoSystemu() {
        airBag = true;
        asr = true;
        abs = true;
        System.out.println("Stav airBagu vodiča: " + airBag);
        System.out.println("Stav systému regulácie prešmykovania asr: " + asr);
        System.out.println("Stav antiblokovacieho systému abs: " + abs);

    }
}