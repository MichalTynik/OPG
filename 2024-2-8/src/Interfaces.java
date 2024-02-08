
interface konvenčnéNastroje{
    void hraj(String nota);
    int cislo = 10;
}

 class DychoveNastroje implements konvenčnéNastroje{
    public void hraj(String nota){System.out.println("Dychove Nastroje hraju "+ nota);}
}

 class Bubny implements konvenčnéNastroje{
    public void hraj(String nota){System.out.println("Bubny hraju "+nota);}
}

 class Husle implements konvenčnéNastroje{
    public void hraj(String nota){System.out.println("Husle hraju "+nota);}
}

 class Pikola extends DychoveNastroje {
    public void hraj(String nota){System.out.println("Pikola hra "+nota);}
}

 class Flauta extends DychoveNastroje{
    public void hraj(String nota){System.out.println("Flauta hra "+ nota);}
}

 class LadenieOrchestra {
    void nalad(String nota){
        DychoveNastroje nastroj = new DychoveNastroje();
        nastroj.hraj(nota);
        nastroj = new Flauta();
        nastroj.hraj(nota);
        nastroj = new Pikola();
        nastroj.hraj(nota);
        Bubny nastroj2 = new Bubny();
        nastroj2.hraj(nota);
        Husle nastroj3 = new Husle();
        nastroj3.hraj(nota);
    }

    public static void main(String[] args) {
        LadenieOrchestra ladenie = new LadenieOrchestra();
        ladenie.nalad("C");
        
    }
}

 