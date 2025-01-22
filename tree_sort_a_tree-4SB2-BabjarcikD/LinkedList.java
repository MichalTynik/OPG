public class LinkedList {
    private Node first;

    public LinkedList() {
        first = null;
    }

    public void append(int value) {
        Node newNode = new Node(value);
        if (first == null) {
            first = newNode;
        } else {
            Node link = first;
            while (link.getNext() != null) {
                link = link.getNext();
            }
            link.setNext(newNode);
        }
    }

    public int length() {
        int count = 0;
        Node link = first;
        while (link != null) {
            count++;
            link = link.getNext();
        }
        return count;
    }

    public boolean deleteAt(int index) {
        if (first == null || index < 0) {
            return false;
        }
        if (index == 0) {
            first = first.getNext();
            return true;
        }
        Node link = first;
        int counter = 0;
        while (counter < index - 1 && link.getNext() != null) {
            counter++;
            link = link.getNext();
        }
        if (link.getNext() == null) {
            return false;
        }
        link.setNext(link.getNext().getNext());
        return true;
    }

    public int getValueI(int index) {
        Node link = first;
        int counter = 0;
        while (counter < index && link != null) {
            counter++;
            link = link.getNext();
        }
        if (link == null) {
            throw new IndexOutOfBoundsException("Index mimo rozsah");
        }
        return link.getValue();
    }

    public void setValueI(int index, int value) {
        Node link = first;
        int counter = 0;
        while (counter < index && link != null) {
            counter++;
            link = link.getNext();
        }
        if (link == null) {
            throw new IndexOutOfBoundsException("Index mimo rozsah");
        }
        link.setValue(value);
    }

    public void prepend(int value) {
        Node newNode = new Node(value);
        newNode.setNext(first);
        first = newNode;
    }

    public boolean deleteByValue(int value) {
        if (first == null) {
            return false;
        }
        if (first.getValue() == value) {
            first = first.getNext();
            return true;
        }
        Node link = first;
        while (link.getNext() != null && link.getNext().getValue() != value) {
            link = link.getNext();
        }
        if (link.getNext() == null) {
            return false;
        }
        link.setNext(link.getNext().getNext());
        return true;
    }

    public String getList() {
        StringBuilder vypis = new StringBuilder("[");
        Node link = first;
        while (link != null) {
            vypis.append(link.getValue()).append(", ");
            link = link.getNext();
        }
        if (vypis.length() > 1) {
            vypis.setLength(vypis.length() - 2);
        }
        vypis.append("]");
        return vypis.toString();
    }

    public int getIndexByValue(int value) {
        Node link = first;
        int counter = 0;
        while (link != null) {
            if (link.getValue() == value) {
                return counter;
            }
            counter++;
            link = link.getNext();
        }
        return -1;
    }
}