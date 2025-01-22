
public class DFIFO {
    private Nodes head;
    private Nodes tail;

    public DFIFO() {
        this.head = null;
        this.tail = null;
    }

    public void put(String value){
        Nodes newNode = new Nodes(value);
        if (this.head == null){
            head = newNode;
            tail = newNode;
        }
        else {
            head.setNext(newNode);
            head = newNode;
        }
    }

    public String get(){
        if(tail == null) return "ERROR - NO DATA";
        String result = tail.getValue();
        tail = tail.getNext();
        if(tail == null) head = null;
        return result;



    }

    @Override
    public String toString() {
        return "DFIFO{" +
                "head=" + (head != null ? head.getValue() : "null") +
                ", tail=" + (tail != null ? tail.getValue() : "null") +
                '}';
    }

}
