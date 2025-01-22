namespace FIFO;

internal class Node
{
               private string value;
               private Node next;

               public Node(string value)
               {
                              this.value = value;
                              next = null;
               }

               public string Value
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
                              return Value;
               }
}