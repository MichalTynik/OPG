package hudobne_nastroje;

class KlavesovyNastroj implements KonvencnyNastroj, ElektronickeNastroje {
    @Override
    public void hraj(String nota) {
        System.out.println("Klávesový nástroj hrá: " + nota);
    }

    @Override
    public void syntetizuj(String nota) {
        System.out.println("Klávesový nástroj syntetizuje: " + nota);
    }
}
