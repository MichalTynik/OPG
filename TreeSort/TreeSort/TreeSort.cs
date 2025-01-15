namespace TreeSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using Tree;

    namespace TreeSort
    {
        internal class TreeSort
        {
            public NodeT root;
            static void Main(string[] args)
            {
                TreeSort tree = new TreeSort();
                tree.Insert(25);
                Console.WriteLine(tree);
                tree.Insert(10);
                Console.WriteLine(tree);
                tree.Insert(100);
                Console.WriteLine(tree);
                tree.Insert(30);
                Console.WriteLine(tree);
                tree.Insert(50);
                Console.WriteLine(tree);
            }

            public TreeSort()
            {
                root = null;
            }

            public void Insert(int x)
            {
                NodeT newNode = new NodeT(x);
                if (root == null)
                {
                    root = newNode;
                    return;
                }

                while (true)
                {
                    if (root.Value < x)
                    {
                        if (root.Right == null)
                        {
                            root.Right = newNode;
                            return;

                        }
                            NodeT link = root;
                    }
                    else
                    {
                        if (root.Left == null)
                        {
                            root.Left = newNode;
                            return;
                        }
                            NodeT link = root;
                    }
                        
                }
            }

            public string Print(NodeT node)
            {
                string result = "";
                if (node.Left != null)
                {
                    result = Print(node.Left);
                }
                result += $"{node.Value}";
                if (node.Right != null)
                {
                    result += Print(node.Right);
                }
                return result;
            }

            public override string ToString()
            {
                //return "Tree{ " +
                //         "root: " + (root != null ? root : "null") + ", " +
                //         "left: " + (root?.Left != null ? root.Left : "null") + ", " +
                //         "right: " + (root?.Right != null ? root.Right : "null") +
                //         " }";
                return Print(root);
            }
        }
    }

}
