
public class Nodes {
    String value;
    Nodes next;

    public Nodes(String value) {
        this.value = value;
        this.next = null;
    }

    public void setNext(Nodes next) {
        this.next = next;
    }

    public Nodes getNext() {
        return this.next;
    }

    public void display() {
        System.out.print(this.value);
        if (this.next != null) {
            System.out.print(" -> ");
            this.next.display();
        } else {
            System.out.println();
        }
    }

    public String getValue() {
        return value;
    }
}
