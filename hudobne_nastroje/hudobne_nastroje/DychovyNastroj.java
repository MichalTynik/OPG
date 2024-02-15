package hudobne_nastroje;

class DychovyNastroj implements KonvencnyNastroj {
    @Override
    public void hraj(String nota) {
        System.out.println("Dychový nástroj hrá: " + nota);
    }
}