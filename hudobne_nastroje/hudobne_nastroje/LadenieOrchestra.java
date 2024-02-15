package hudobne_nastroje;

class LadenieOrchestra {
    public static void naladOrchester(KonvencnyNastroj[] orchester, String nota) {
        for (KonvencnyNastroj nastroj : orchester) {
            nastroj.hraj(nota);
        }
    }

    public static void naladElektroOrchester(ElektronickeNastroje[] elektroOrchester, String nota) {
        for (ElektronickeNastroje nastroj : elektroOrchester) {
            nastroj.syntetizuj(nota);
        }
    }
}