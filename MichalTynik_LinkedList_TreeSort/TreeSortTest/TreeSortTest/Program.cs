using System.Diagnostics;
using TreeSortTest;

internal class Program
{
               public static void Main(string[] args)
               {
                              Random rn = new Random();
                              Stopwatch sw = new Stopwatch();

                              Console.WriteLine("Pocet nahodnich cisel: ");
                              int.TryParse(Console.ReadLine(), out int pocet);
                              Console.WriteLine("Nahodne [N]\nVzostupne [V}\nZostupne [Z]");
                              string sposob = Console.ReadLine();

                              for (int i = 0; i < 10; i++)
                              {
                                             DoTreeSort();
                              }
                              
                              
                              List<int> RandomInput(int pocetLink, string sposobLink)
                              {
                                             List<int> list = new List<int>();
                                             list = new List<int>();
                                             switch (sposobLink)
                                             {
                                                            case "N":
                                                                           for (int i = 0; i < pocetLink; i++)
                                                                           {
                                                                                          list.Add(rn.Next(0, 10000));
                                                                           }
                                                                           break;
                                                            case "V":
                                                                           for (int i = 0; i < pocetLink; i++)
                                                                           {
                                                                                          if (i==0)
                                                                                                         list.Add(rn.Next(0, 10));
                                                                                          else
                                                                                                         list.Add(rn.Next(0, 10)+1);
                
                                                                           }
                                                                           break;
                                                            case "Z":
                                                                           for (int i = 0; i < pocetLink; i++)
                                                                           {
                                                                                          if (i==0)
                                                                                                         list.Add(rn.Next(0, 10));
                                                                                          else
                                                                                                         list.Add(rn.Next(0, 10)-1);
                                                                           }
                                                                           break;
                                             }
                                             return list;
                              }

//Spustacia trieda pre TreeSort
                              void DoTreeSort()
                              {
                                             List<int> list = RandomInput(pocet, sposob);
                                             sw.Start();
                                             TreeSort treeSort = new TreeSort();
    
                                             foreach (var VARIABLE in list)
                                             {
                                                            treeSort.Insert(VARIABLE);
                                             }
                                             long counter = treeSort.Steps;
                                             sw.Stop();
                                             Console.WriteLine($"TreeSort: Pocet krokov = {counter}, Cas(ms) = {sw.ElapsedMilliseconds}");
                                             sw.Reset();
                              }
               }
}