
using FIFO;

FIFOClass fifo = new FIFOClass(10);
ConsoleKeyInfo cskey = new ConsoleKeyInfo();
while (cskey.Key != ConsoleKey.C)
{
               Console.WriteLine("Ovladanie Enter => Vyber/Vloz\nMedzernik => Vypis");
               cskey = Console.ReadKey();
               Console.WriteLine("------------");
               if (cskey.Key == ConsoleKey.Enter)
               {
                              Random rnd = new Random();
                              int i = rnd.Next(1, 3);
                              if (i == 1)
                              {
                                             Console.WriteLine("vklad");
                                             fifo.Put();
                              }
                              else{
                                             Console.WriteLine("vyber");
                                             fifo.Get();
                              }

               }

               if (cskey.Key == ConsoleKey.Spacebar)
               {
                              fifo.Print();
               }    
}

/// <summary>
/// Trieda ktora sa stara o text piesne
/// </summary>
public class FIFOClass
{
               Music music = new Music();
               readonly string _path = "KaraokeText";
               FIFO.LinkedList linked = new LinkedList();

               /// <summary>
               /// Konstruktor pre triedu FIFO
               /// </summary>
               /// <param name="capacity">Velkost buffera</param>
               public FIFOClass(int capacity)
               {
                              linked = new LinkedList();
                              
               }

               /// <summary>
               /// Vypise _head, _tail a buffer
               /// </summary>
               public void Print()
               {
                              Console.WriteLine(linked.List);
               }

               /// <summary>
               /// Data posle z internetu / Vlozi slovo z txt do buffera
               /// </summary>
               public void Put()
               {
                                             string newData = music.Lyrics();
                                             linked.Append(newData);
               }

               /// <summary>
               /// Vypise slovo z buffera
               /// </summary>
               public void Get()
               {
                              if (linked.List.Length > 0)
                              {
                                             Console.WriteLine(linked.GetValue(0));
                                             linked.DeleteAt(0);
                              }
                              else 
                                             Console.WriteLine("DATA NOT LOADED");
                              
               }
}