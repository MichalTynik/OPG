package hudobne_nastroje;

class Bubny implements KonvencnyNastroj {
    @Override
    public void hraj(String nota) {
        System.out.println("Bubny hrajú: " + nota);
    }
}