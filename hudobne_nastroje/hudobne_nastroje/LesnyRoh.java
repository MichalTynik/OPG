package hudobne_nastroje;

class LesnyRoh implements PlechoveNastroje {
    @Override
    public void hraj(String nota) {
        System.out.println("Lesný roh hrá: " + nota);
    }

    @Override
    public void zatrub() {
        System.out.println("Lesný roh trúbí.");
    }
}