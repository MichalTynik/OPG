namespace FIFO;

public class LinkedList
{
        private Node prvy;
        private string _list;
        private string _index;

        public string List
        {
            get
            {
                Node link = prvy;
                _list = "[ ";
                for (int i = 0; i < Length(); i++)
                {
                    _list += link.Value.ToString() + ", ";
                    link = link.Next;
                }
                _list = _list.Trim(',', ' ');
                _list += "]";
                return _list;
            }
        }

        public string GetValue(int index)
        {
            if (prvy == null || index < 0)
            {
                Console.Error.WriteLine("DATA NOT LOADED");
                return null;
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
                Console.Error.WriteLine("DATA NOT LOADED");
                return null;
            }
            return link.Value;
        }

        public void SetValue(int index, string value)
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

        public LinkedList()
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

        public int GetIndex(string value)
        {

            Node link = prvy;
            int counter = 0;
            if (link == null)
            {
                Console.WriteLine("List je prazdny");
                return -1;
            }
            while (link.Next != null)
            {
                if (link.Value == value)
                    return counter;
                counter++;
                link = link.Next;
            }
            Console.WriteLine("Hodnota sa nenachadza v liste");
            return -1;
        }

        public bool DeleteAt(int index)
        {
            if (prvy == null || index < 0)
            {
                return false;
            }
            if (index == 0)
            {
                prvy = prvy.Next;
                return true;
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
                    return false;
                }
                link.Next = link.Next.Next;
                return true;
            
        }

        public void InsertAfter(int index, string value)
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

        public void Append(string value)
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
            return prvy.ToString();
        }
    }        
