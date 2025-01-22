using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    internal class NodeT(int value)
    {
        private int value = value;

        public int Value
        {
            get => value;
            set => this.value = value;
        }
        public NodeT? Left { get; set; }

        public NodeT? Right { get; set; }
        public override String ToString()
        {
            
            return value.ToString();
        }

    }
}
