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

        public void append(int value)
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
