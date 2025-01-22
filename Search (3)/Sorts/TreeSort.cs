namespace Sorts;

public class TreeSort
{
               public static NodeT root;
               public long Steps = 0;
               public TreeSort()
               {
                              root = null;
               }

               public void Insert(int x)
               {
                              root = InsertRec(root, x);
               }

               private NodeT? InsertRec(NodeT? rootLink, int x)
               {
                              if (rootLink == null)
                                             return new NodeT(x);

                              if (x < rootLink.Value)
                              {
                                             Steps++;
                                             rootLink.Left = InsertRec(rootLink.Left, x);
                                             
                              }
                              else{
                                             Steps++;
                                             rootLink.Right = InsertRec(rootLink.Right, x);
                                             
                              }

                              return rootLink;
               }


               // private List<int> Print(List<int> values, NodeT rootLink)
               // {
               //     if (rootLink != null)
               //     {
               //         
               //         values.Add(rootLink.Value);
               //         Print(values, rootLink.Left);
               //         Print(values, rootLink.Right);
               //     }
               //     return values;
               // }

               private List<int> Print(List<NodeT> nodes, List<int> list)
               {
                              if (nodes.Count == 0)
                              {
                                             nodes.Add(root);
                                             list.Add(root.Value);
                              }

                              for (int i = 0; i < nodes.Count; i++)
                              {
                                             if (nodes[i].Left != null)
                                             {
                                                            nodes.Add(nodes[i].Left);
                                                            list.Add(nodes[i].Left.Value);
                                             }

                                             if (nodes[i].Right != null)
                                             {
                                                            nodes.Add(nodes[i].Right);
                                                            list.Add(nodes[i].Right.Value);
                                             }

                                             nodes.Remove(nodes[i]);
                              }

                              return list;
               }


               public override string ToString()
               {
                              List<int> list = Print(new List<NodeT>(), new List<int>());
                              string result = string.Empty;
                              for (int i = 0; i < list.Count; i++)
                              {
                                             if (i == 0)
                                                            result += list[i].ToString() + "\n";
                                             else
                                             {
                                                            if (i + 1 < list.Count && list[i] < list[i + 1] &&
                                                                list[i - 1] < list[i + 1])
                                                                           result += list[i].ToString() + " ";
                                                            else
                                                                           result += list[i].ToString() + "\n";
                                             }
                              }

                              return result;
               }
}