using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LinkedList
{
    internal class MojLinkedList
    {
        private Node prvy;

        public int GetValue(int index)
        {
            if (prvy == null || index < 0)
            {
                Console.Error.WriteLine("List je prazdny alebo si zadal zaporny index");
                return -1;
            }
            Node link = prvy;
            int counter = 0;
            while (counter < index && link.Next != null)
            {
                counter++;
                link = link.Next;
            }
            if (counter < index)
            {
                Console.Error.WriteLine("List je prazdny alebo si zadal zaporny index");
                return -1;
            }
            return link.Value;
        }

        public void SetValue(int index, int value)
        {
            if (prvy == null || index < 0)
            {
                Console.Error.WriteLine("List je prazdny alebo si zadal zaporny index");
                return;
            }
            Node link = prvy;
            int counter = 0;
            while (counter < index && link.Next != null)
            {
                counter++;
                link = link.Next;
            }
            if (counter < index)
            {
                Console.Error.WriteLine("List je prazdny alebo si zadal zaporny index");
                return;
            }
            link.Value = value;
        }

        public MojLinkedList()
        {
            prvy = null;
        }

        public int Length()
        {
            int counter = 0;
            if (prvy == null)
            {
                return counter;
            }
            counter++;
            Node link = prvy;
            while (link.Next != null)
            {
                counter++;
                link = link.Next;
            }
            return counter;
        }

        public bool DeleteAt(int index)
        {
            if (prvy == null || index < 0)
            {
                Console.Error.WriteLine("List je prazdny alebo si zadal zaporny index");
                return false;
            }
            else
            if (index == 0)
            {
                prvy = prvy.Next;
                return true;
            }
            else
            {
                Node link = prvy;
                int counter = 0;
                while (counter < index && link.Next != null)
                {
                    counter++;
                    link = link.Next;
                }
                if (counter < index)
                {
                    Console.Error.WriteLine("List je prazdny alebo si zadal zaporny index");
                    return false;
                }
                link.Next = link.Next.Next;
                return true;
            }
        }

        public void InsertAfter(int index, int value)
        {
            Node newNode = new Node(value);
            if (prvy == null)
                prvy = newNode;
            else
                if (index < 0)
            {
                newNode.Next = prvy;
                prvy = newNode;
            }
            else
            {
                Node link = prvy;
                int counter = 0;
                while (counter < index && link.Next != null)
                {
                    counter++;
                    link = link.Next;
                }
                newNode.Next = link.Next;
                link.Next = newNode;
            }
        }

        public void Append(int value)
        {
            Node node = new Node(value);
            if (prvy == null) prvy = node;
            else
            {
                Node link = prvy;
                while (link.Next != null) link = link.Next;
                link.Next = node;
            }
        }
        public override string ToString()
        {
            return "prvy = " + prvy;
        }
    }
}
