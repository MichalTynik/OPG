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

            public static NodeT? root;
            static void Main(string[] args)
            {

                TreeSort tree = new TreeSort();

                tree.Insert(ref root, 25);
                Console.WriteLine(tree);
                tree.Insert(ref root, 10);
                Console.WriteLine(tree);
                tree.Insert(ref root, 100);
                Console.WriteLine(tree);
                tree.Insert(ref root, 30);
                Console.WriteLine(tree);
                tree.Insert(ref root, 50);
                Console.WriteLine(tree);
            }

            public TreeSort()
            {
                root = null;
            }

            public void Insert(ref NodeT node, int x)
            {
                if (node == null)
                {
                    node = new NodeT(x);
                    return;
                }

                if (x < node.Value)
                {
                    node = node.Left;
                    Insert(ref node, x);
                }
                else
                {
                    node = node.Right;
                    Insert(ref node, x);
                }
            }
            private string Print(List<NodeT> nodes, string res)
            {
                if (nodes == null || !nodes.Any())
                    return res;

                List<NodeT> nextLevel = new List<NodeT>();

                foreach (var item in nodes)
                {
                    res += item.ToString() + " ";
                    if (item.Left != null)
                        nextLevel.Add(item.Left);
                    if (item.Right != null)
                        nextLevel.Add(item.Right);
                }

                res += "\n";
                return Print(nextLevel, res);
            }


            public override string ToString()
            {
                return Print(new List<NodeT>() { root }, "");
            }
        }
    }
}


