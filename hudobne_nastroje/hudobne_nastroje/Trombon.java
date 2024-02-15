package hudobne_nastroje;

class Trombon implements PlechoveNastroje {
    @Override
    public void hraj(String nota) {
        System.out.println("Trombón hrá: " + nota);
    }

    @Override
    public void zatrub() {
        System.out.println("Trombón trúbí.");
    }
}
