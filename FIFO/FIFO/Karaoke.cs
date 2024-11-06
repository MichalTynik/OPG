namespace FIFO;

public class Karaoke
{
               public void Subor()
               {
                              using (StreamWriter sw = new StreamWriter("KaraokeText.txt", true))
                              {
                                             sw.WriteLine("streamWriter");
                              }

                              using (StreamReader sr = new StreamReader("KaraokeText.txt"))
                              {
                                             string s;
                                             while ((s = sr.ReadLine()) != null)
                                             {
                                                            Console.WriteLine(s);
                                             }
                              }
               }
}