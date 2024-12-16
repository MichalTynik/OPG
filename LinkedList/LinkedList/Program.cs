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
            mojlist.Append(123);
            Console.WriteLine(mojlist);
            mojlist.Append(456);
            Console.WriteLine(mojlist);
            mojlist.Append(789);
            Console.WriteLine(mojlist);
            Console.WriteLine(mojlist.Length());
            Console.WriteLine(mojlist.GetValue(1));
            Console.WriteLine(mojlist.GetValue(-2));
            mojlist.SetValue(0, 555);
            Console.WriteLine(mojlist);
            mojlist.DeleteAt(0);
            Console.WriteLine(mojlist);
            mojlist.InsertAfter(0, 444);
            Console.WriteLine(mojlist);
            Console.WriteLine(mojlist.List);
            Console.WriteLine(mojlist.GetIndex(555));
            Console.WriteLine(mojlist.GetIndex(456));
        }
    }
}
