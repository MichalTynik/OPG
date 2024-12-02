namespace LIFO;

public class LabFile
{
               private int[] _types = {1,2,4,8};
               private int[] start;
               private int[] end;
               string[] all = new string[] { };
               public int[] Start
               {
                              get => start;
                              set => start = value ?? throw new ArgumentNullException(nameof(value));
               }

               public int[] End
               {
                              get => end;
                              set => end = value ?? throw new ArgumentNullException(nameof(value));
               }

               public LabFile()
               {
                              using (StreamReader sr = new StreamReader("lab.txt"))
                              {
                                             string str = sr.ReadToEnd();
                                             all = str.Split(new char[]{' ', '\n'});
                              }
                              Array.ForEach(all, Console.WriteLine);
                              LabInfo(all[all.Length-2],true);
                              LabInfo(all[all.Length-1],false);
               }

               void LabInfo(string info, bool startInfo)
               {
                              string[] seperate = info.Split('x');
                              if (startInfo)
                              {
                                             for (int i = 0; i < seperate.Length; i++)
                                             {
                                                            int.TryParse(seperate[i], out Start[i]);
                                             } 
                              }
                              else
                              {
                                             for (int i = 0; i < seperate.Length; i++)
                                             {
                                                            int.TryParse(seperate[i], out End[i]);
                                             } 
                              }
                              
               }              

               public Doors LabTranslation(int row, int column)
               {
                              Doors doors = new Doors();
                              int number = int.Parse(all[row][column]);
                              if (number - 8 >= 0)
                              {
                                             doors.Zapad = true;
                                             number -= 8;
                                             if (number - 4 >=0)
                                             {
                                                            doors.Juh = true;
                                                            number -= 4;
                                                            if (number - 2 >= 0)
                                                            {
                                                                           doors.Vychod = true;
                                                                           number -= 2;
                                                                           if (number - 1 >= 0)
                                                                           {
                                                                                          doors.Sever = true;
                                                                           }
                                                            }
                                             }
                              }
                              return doors;
               }
}

public class Doors
{
               private bool sever, vychod, juh, zapad;

               public bool Sever
               {
                              get => sever;
                              set => sever = value;
               }

               public bool Vychod
               {
                              get => vychod;
                              set => vychod = value;
               }

               public bool Juh
               {
                              get => juh;
                              set => juh = value;
               }

               public bool Zapad
               {
                              get => zapad;
                              set => zapad = value;
               }
}