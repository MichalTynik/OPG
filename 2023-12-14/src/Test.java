
public class Test {
    public static void main(String[] args) {
        Pomaranc p = new Pomaranc("Spanielsko");
        Jablko j = new Jablko("Citronka");
        Banan b = new Banan("zrely");
        System.out.println("----------------------------------------------------------------");
        System.out.println(p.nazov + " | " + p.farba + " | "  + p.povod + " | " + p.vaha + "g");
        System.out.println("----------------------------------------------------------------");
        System.out.println(j.nazov + " | " + j.farba + " | "  + j.odroda + " | " + j.vaha + "g");
        System.out.println("----------------------------------------------------------------");
        System.out.println(b.nazov + " | " + b.farba + " | "  + b.zrelost + " | " + b.vaha + "g");
    }

}

class Ovocie {
    String nazov;
    String farba;
    int vaha;

    Ovocie(String nazov, String farba, int vaha) {
        this.nazov = nazov;
        this.farba = farba;
        this.vaha = vaha;
    }

    public String getNazov() {
        return nazov;
    }

    public String getFarba() {

        return farba;
    }

    public int getVaha() {
        return vaha;
    }

    public void setValues(String nazov, String farba, int vaha) {
        this.nazov = nazov;
        this.farba = farba;
        this.vaha = vaha;
    }
}

class Banan extends Ovocie {
    String zrelost;

    public String getZrelost() {
        return zrelost;
    }

    public void setZrelost(String zrelost) {
        this.zrelost = zrelost;
    }

    Banan(String zrelost) {
        super("Banan", "zlty", 230);
        this.zrelost = zrelost;
    }
}

class Jablko extends Ovocie {
    String odroda;

    public String getOdroda() {
        return odroda;
    }

    public void setOdroda(String odroda) {
        this.odroda = odroda;
    }

    Jablko(String odroda) {
        super("Jablko", "zelene", 130);
        this.odroda = odroda;
    }
}

class Pomaranc extends Ovocie {
    String povod;

    public String getPovod() {
        return povod;
    }

    public void setPovod(String povod) {
        this.povod = povod;
    }

    Pomaranc(String povod) {
        super("Pomaranc", "oranzovy", 230);
        this.povod = povod;
    }
}