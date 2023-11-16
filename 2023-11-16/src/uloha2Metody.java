package src;

public class uloha2Metody {
    private int id;
    private String meno;
    
    public String getMeno(){
        return  meno;
    }

    public int getID(){
        return id;
    }

    public void setID(int id){
        this.id = id;
    }

    public void setMeno(String meno){
        this.meno = meno;
    }

    public void zobrazi(){
        System.out.println("ID: " + id);
        System.out.println("MENO: " + meno);
    }

    public static void zobrazi2(int id , String meno) {
        System.out.println("ID: " + id);
        System.out.println("MENO: " + meno);
    }
}