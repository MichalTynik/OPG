namespace FIFO;

public class Music
{
               int position;
               public string Lyrics()
               {
                              
                              string[] words = new string[]{};
                              string line;
                              using (StreamReader sr = new StreamReader(File.OpenRead("KaraokeText")))
                              {
                                             if (words.Length == 0)
                                             {
                                                        line =  sr.ReadToEnd();    
                                                        words = line.Split(new char[]{' ', '\n'});
                                             }

                                             if (position < words.Length)
                                             {              
                                                            string word = words[position];
                                                            position++;
                                                            Console.WriteLine(word
                                                            );
                                                            return word;
                                             }

                                             return "NO DATA";
                              }
               }

}