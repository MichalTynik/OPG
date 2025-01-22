


public class TestDFIFO {
    public static void main(String[] args) {
        DFIFO fifo = new DFIFO();  //FIFO fifo = new FIFO(10);
        fifo.put("Prší, ");
        System.out.println(fifo);
        fifo.put("prší");
        System.out.println(fifo);
        fifo.put("len");
        System.out.println(fifo);
        fifo.put("sa");
        fifo.put("leje");
        System.out.println(fifo);
        System.out.println(fifo.get());
        System.out.println(fifo.get());
        System.out.println(fifo.get());
        System.out.println(fifo.get());
        System.out.println(fifo.get());

    }
}
