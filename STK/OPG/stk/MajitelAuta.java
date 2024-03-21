package OPG.stk;
public class MajitelAuta {
    private final String meno;
    private final String mesto;
    private final String cisloOp;

    public MajitelAuta(String meno, String mesto, String cisloOp) {
        this.meno = meno;
        this.mesto = mesto;
        this.cisloOp = cisloOp;
    }

    public String getMeno() {
        return meno;
    }

    public String getMesto() {
        return mesto;
    }

    public String getCisloOp() {
        return cisloOp;
    }
}
