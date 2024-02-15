package hudobne_nastroje;

class ElektrickaGitara implements ElektronickeNastroje {
    @Override
    public void syntetizuj(String nota) {
        System.out.println("Elektrická gitara syntetizuje: " + nota);
    }
}