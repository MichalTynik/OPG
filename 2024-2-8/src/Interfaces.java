
import java.util.Stack;

interface konvenčnéNastroje{
    void hraj(String nota);
    int cislo = 10;
}

interface elektronickeNastroje{
    void syntetizuj();
}

interface plechoveNastroje extends konvenčnéNastroje{
    void zatrub();
}

class klavesove implements konvenčnéNastroje, elektronickeNastroje{
    public void hraj(String nota){System.out.println("Klavesy hraju "+nota);};
    public void syntetizuj(){System.out.println("Syntetizujem");};
}

class elektrickaGitara implements elektronickeNastroje{
    public void syntetizuj(){System.out.println("Syntetizujem");};
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

class trombon implements plechoveNastroje{
    public void zatrub(){System.out.println("Trombon trubi");};
    public void hraj(String nota){System.out.println("Trombon hraje "+nota);};
}

class lesnyRoh implements plechoveNastroje{
    public void zatrub(){System.out.println("Roh trubi");};
    public void hraj(String nota){System.out.println("Roh hraje "+nota);};
}
 class LadenieOrchestra {
    void nalad(String nota){
        Stack<konvenčnéNastroje> nastroje = new Stack<konvenčnéNastroje>();
        nastroje.add(new DychoveNastroje());
        nastroje.add(new Flauta());
        nastroje.add(new Bubny());
        nastroje.add(new Husle());
        nastroje.add(new Pikola());
        nastroje.add(new klavesove());
        for (konvenčnéNastroje nastroj : nastroje) {
            nastroj.hraj(nota);
        }
        Stack<elektronickeNastroje> ele = new Stack<elektronickeNastroje>();
        ele.push(new elektrickaGitara());
        ele.push(new klavesove());
        for (elektronickeNastroje elektronickeNastroje : ele) {
            elektronickeNastroje.syntetizuj();
        }

        Stack<plechoveNastroje> stack = new Stack<plechoveNastroje>();
        stack.push(new trombon());
        stack.push(new lesnyRoh());
        for (plechoveNastroje plechoveNastroje : stack) {
            plechoveNastroje.hraj(nota);
            plechoveNastroje.zatrub();
        }
    }

    public static void main(String[] args) {
        LadenieOrchestra ladenie = new LadenieOrchestra();
        ladenie.nalad("C");
        
    }
}

 