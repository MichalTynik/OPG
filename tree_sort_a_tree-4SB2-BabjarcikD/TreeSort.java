public class TreeSort {
    private NodeT root;
    public int stepCounter;

    public TreeSort() {
        root = null;
        stepCounter = 0;
    }

    public void insert(int value) {
        NodeT newNode = new NodeT(value);
        if (root == null) {
            root = newNode;
            return;
        }

        NodeT current = root;
        while (true) {
            stepCounter++;
            if (value < current.getValue()) {
                if (current.getLeft() == null) {
                    current.setLeft(newNode);
                    break;
                }
                current = current.getLeft();
            } else {
                if (current.getRight() == null) {
                    current.setRight(newNode);
                    break;
                }
                current = current.getRight();
            }
        }
    }

    public NodeT getRoot() {
        return root;
    }

    private String inOrderTraversal(NodeT node) {
        if (node == null) {
            return "";
        }
        return inOrderTraversal(node.getLeft()) + node.getValue() + " " + inOrderTraversal(node.getRight());
    }

    public String getTreeSort() {
        return inOrderTraversal(root).trim();
    }

    public void buildTree(int[] array) {
        root = null;
        stepCounter = 0;
        for (int value : array) {
            insert(value);
        }
        System.out.println("Steps taken during buildTree: " + stepCounter);
    }

    public int search(int value) {
        int[] indexCounter = {0};
        stepCounter = 0;
        int result = searchRecursive(root, value, indexCounter);
        System.out.println("Steps taken during search: " + stepCounter);
        return result;
    }

    private int searchRecursive(NodeT node, int value, int[] indexCounter) {
        if (node == null) {
            return -1;
        }

        stepCounter++;

        int leftResult = searchRecursive(node.getLeft(), value, indexCounter);
        if (leftResult != -1) {
            return leftResult;
        }

        if (node.getValue() == value) {
            return indexCounter[0];
        }
        indexCounter[0]++;

        return searchRecursive(node.getRight(), value, indexCounter);
    }
}
