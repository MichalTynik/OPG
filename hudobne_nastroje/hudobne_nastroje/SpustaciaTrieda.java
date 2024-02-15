package hudobne_nastroje;

public class SpustaciaTrieda {
    public static void main(String[] args) {

        KonvencnyNastroj[] orchester = {
                new DychovyNastroj(),
                new Bubny(),
                new Husle(),
                new Pikola(),
                new Flauta(),
                new KlavesovyNastroj(),
                //new ElektrickaGitara(),
                new Trombon(),
                new LesnyRoh()
        };


        LadenieOrchestra.naladOrchester(orchester, "stredné C");

        // Vytvorenie a naladenie elektro orchestra
        ElektronickeNastroje[] elektroOrchester = {
                new KlavesovyNastroj(),
                new ElektrickaGitara(),
                //new Trombon()
        };

        LadenieOrchestra.naladElektroOrchester(elektroOrchester, "elektronická nota");

        PlechoveNastroje trombonOdkaz = new Trombon();
        trombonOdkaz.zatrub();
    }
}