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

                tree.Insert(25);
                Console.WriteLine(tree);
                tree.Insert( 10);
                Console.WriteLine(tree);
                tree.Insert( 100);
                Console.WriteLine(tree);
                tree.Insert( 30);
                Console.WriteLine(tree);
                tree.Insert(50);
                Console.WriteLine(tree);
                tree.Insert(120);
                Console.WriteLine(tree);
            }

            public TreeSort()
            {
                root = null;
            }

            public void Insert(int x)
            {
                root = InsertRec(root, x);
            }

            private NodeT? InsertRec(NodeT? rootLink, int x)
            {
                if (rootLink == null)
                    return new NodeT(x);

                if (x < rootLink.Value)
                    rootLink.Left = InsertRec(rootLink.Left, x);
                else
                    rootLink.Right = InsertRec(rootLink.Right, x);
                
                return rootLink;
            }
            
            
            // private List<int> Print(List<int> values, NodeT rootLink)
            // {
            //     if (rootLink != null)
            //     {
            //         
            //         values.Add(rootLink.Value);
            //         Print(values, rootLink.Left);
            //         Print(values, rootLink.Right);
            //     }
            //     return values;
            // }

            private List<int> Print(List<NodeT> nodes, List<int> list)
            {
                if (nodes.Count == 0)
                {
                    nodes.Add(root);
                    list.Add(root.Value);
                }

                for (int i = 0; i < nodes.Count; i++)
                {
                    if (nodes[i].Left != null)
                    {
                        nodes.Add(nodes[i].Left);
                        list.Add(nodes[i].Left.Value);
                    }

                    if (nodes[i].Right != null)
                    {
                        nodes.Add(nodes[i].Right);
                        list.Add(nodes[i].Right.Value);
                    }
                    nodes.Remove(nodes[i]);
                }
                return list;
            }
            

            public override string ToString()
            {
                List<int> list = Print(new List<NodeT>(), new List<int>());
                string result = string.Empty;
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == 0)
                        result +=list[i].ToString() + "\n";
                    else
                    {
                        if (i +1 < list.Count && list[i] < list[i + 1] && list[i -1] < list[i+1])
                            result +=  list[i].ToString() + " ";
                        else
                            result +=  list[i].ToString() + "\n";
                    }
                    
                }
                return result;
            }
        }
    }
}


