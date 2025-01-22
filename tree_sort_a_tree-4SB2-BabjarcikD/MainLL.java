
public class MainLL {
    public static void main(String[] args) {
        LinkedList mojList = new LinkedList();
        System.out.println(mojList);
        mojList.append(123);
        System.out.println(mojList);
        mojList.append(456);
        System.out.println(mojList);
        mojList.append(789);
        System.out.println(mojList);
        mojList.append(101112);
        System.out.println(mojList);
        mojList.append(131415);
        System.out.println(mojList);
        mojList.append(161718);
        System.out.println(mojList);
        System.out.println(mojList.length());
        System.out.println(mojList.getValueI(10));
        mojList.setValueI(6, 54321);
        mojList.insertAfter(-1, 192021);
        System.out.println(mojList);
        if (mojList.deleteAt(-1)) System.out.println("Zmazané");
        else System.out.println("Index mimo rozsah");
        System.out.println(mojList);
        System.out.println(mojList.getList());
        System.out.println(mojList.getIndexByValue(888));
    }
}