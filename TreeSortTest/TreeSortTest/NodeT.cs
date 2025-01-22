namespace TreeSortTest;

public class NodeT(int value)
{
               private int _value = value;

               public int Value
               {
                              get => _value;
                              set => this._value = value;
               }

               public NodeT? Left { get; set; }

               public NodeT? Right { get; set; }

               public override String ToString()
               {
                              return value.ToString();
               }
}