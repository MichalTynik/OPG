using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class Node
    {
        private int value;
        private Node next;

        public Node(int value)
        {
            this.value = value;
            next = null;
        }
        public int Value
        {
            get => value;
            set => this.value = value;
        }
        public Node Next
        {
            get => next;
            set => this.next = value;
        }

        public override String ToString()
        {
            return "Node{" +
                    "value=" + value +
                    ", next=" + next +
                    '}';
        }

    }
}
