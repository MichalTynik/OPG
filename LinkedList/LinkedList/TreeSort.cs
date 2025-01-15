using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class TreeSort
    {
        public NodeT root;
        static void Main(string[] args)
        {
            TreeSort tree = new TreeSort();
            Random rn = new Random();
            for (int i = 0; i < 10; i++)
            {
                int x = rn.Next(100);
                Console.WriteLine(x);
                tree.Insert(x);
            }
            Console.WriteLine(tree);

        }

        public TreeSort()
        {
            root = null;
        }

        public void Insert(int x)
        {
            NodeT newNode = new NodeT(x);
        }

        //public override string ToString()
        //{
        //}
    }
}
