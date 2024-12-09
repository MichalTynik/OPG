using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MojLinkedList mojlist = new MojLinkedList();
            Console.WriteLine(mojlist);
            mojlist.append(123);
            Console.WriteLine(mojlist);
            mojlist.append(456);
            Console.WriteLine(mojlist);
            mojlist.append(789);
            Console.WriteLine(mojlist);
            Console.WriteLine(mojlist.Length());
        }
    }
}
