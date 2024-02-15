package hudobne_nastroje;

class Flauta extends DychovyNastroj {
    @Override
    public void hraj(String nota) {
        System.out.println("Flauta hrá: "+ nota);
    }
}