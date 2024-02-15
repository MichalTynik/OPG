package hudobne_nastroje;

class Husle implements KonvencnyNastroj {
    @Override
    public void hraj(String nota) {
        System.out.println("Husle hrajú: " + nota);
    }
}