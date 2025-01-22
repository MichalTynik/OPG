namespace LIFO;

class Program
{
               private int _top = -1;
               private bool _hasKey = false;
               private bool _won = false;
               private int[] _end , _start;
               
               List<int[]> _lifo = new List<int[]>();
               
               LabFile _lf = new LabFile();
               
               private string[] _doorDrawing = ["  \u2190  ","   \u2193  ","  \u2192  ",  "   \u2191  "];
               private string[] _wallDrawing = [  "|  ","  ---  ", "  |", "  ---  "];
               
               public static void Main(string[] args)
               {
                              Program p = new Program();
                              p.Start();
                              Console.WriteLine("Vyhral si! Press any key to exit...");
                              Console.ReadLine();
               }
               
               /// <summary>
               /// Spusti hru Labyrint
               /// </summary>
               void Start()
               {
                              _end = LabInfo();
                              _start = LabInfo();
                              Update(_start, true);
                              while (!_won)
                              {
                                             Console.WriteLine();
                                             Console.Write("Zadaj smer do ktoreho chces ist (SEVER, VYCHOD, JUH, ZAPAD, NAVRAT): ");
                                             string? answer = Console.ReadLine();
                                             Console.Clear();
                                             TranslateAndUpdate(answer);
                                             Check(_lifo[_top]);
                              }
               }

               /// <summary>
               /// Zisti startovacie policko aj policko s klucom
               /// </summary>
               /// <returns></returns>
               int[] LabInfo()
               {
                              int[][] lab = _lf.Labyrint;
                              for (int i = 0; i < 5; i++)
                              {
                                             for (int j = 0; j < 5; j++)
                                             {
                                                            if (lab[i][j] - 32 > 0){
                                                                           _lf.Labyrint[i][j] -= 32;
                                                                           return [i,j];
                                                            }
                                                            if ( lab[i][j]- 16 > 0)
                                                            {
                                                                           _lf.Labyrint[i][j] -= 16;
                                                                           return [i,j];
                                                            }
                                             }
                              }
                              return null;
               }

               /// <summary>
               /// Nakresli miestnost
               /// </summary>
               /// <param name="code"></param>
               private void Draw(int code)
               {
                              bool[] doorsCode = CodeTranslation(code);
                              int i = 3;
                              while (i != -1)
                              {
                                             if (i == 3)
                                             {
                                                            Console.WriteLine(doorsCode[i]        
                                                                           ? _doorDrawing[i]      
                                                                           : _wallDrawing[i]);
                                                            i = 0;
                                             }
                                             if (i == 1)
                                             {
                                                            Console.Write(doorsCode[i]         
                                                                           ? _doorDrawing[i]   
                                                                           : _wallDrawing[i]);
                                                            i = -1;
                                             }
                                             if (i == 2)
                                             {
                                                            Console.Write(_top);
                                                            Console.WriteLine(doorsCode[i]
                                                                           ? _doorDrawing[i]
                                                                           : _wallDrawing[i]);
                                                            i = 1;
                                             }
                                             if (i == 0)
                                             {              
                                                            Console.Write(doorsCode[i]
                                                                           ? _doorDrawing[i]
                                                                           : _wallDrawing[i]);
                                                            i = 2;
                                             }
                              }
               }

               /// <summary>
               /// Zisti kde sa nachadzaju dvere podla cisla izby
               /// </summary>
               /// <param name="code"></param>
               /// <returns>Premennu bool[] s hodnotami true a false ktore hovoria ci ma dana stena dvere</returns>
               private bool[] CodeTranslation(int code)
               {
                              bool[] doors = new bool[4];
                              int num = 8;
                              for (int i = 0; i < 4; i++)
                              {
                                             if (code - num >= 0)
                                             {
                                                            doors[i] = true;
                                                            code -= num;
                                                            num = num / 2;              
                                             }
                                             else
                                             {
                                                            doors[i] = false;
                                                            num = num / 2;
                                             }
                              }
                              return doors;
               }
               
               /// <summary>
               /// Skontroluje ci nahodou izba neskriva kluc alebo ci sme nevyhrali
               /// </summary>
               /// <param name="room"></param>
               private void Check(int[]? room)
               {
                              if (room.SequenceEqual(_end))
                              {
                                       _hasKey = true;
                                       Console.WriteLine("\nZiskal si kluc");
                              }

                              if (room.SequenceEqual(_start) && _hasKey)
                              {
                                             _won = true;
                              }
               }

               /// <summary>
               /// Aktualizuje lifo a posle kod miestnosti pre metodu Draw
               /// </summary>
               /// <param name="room">Suradnice miestnosti</param>
               /// <param name="forward">true - postupujeme dalej, false - vraciame sa</param>
               private void Update(int[]? room, bool forward)
               {
                              
                              if (forward)
                              {
                                             _lifo.Add(room);
                                             _top++;   
                                             Draw(_lf.Labyrint[room[0]][room[1]]);
                              }
                              else
                              {
                                             if (_top != 0)
                                             {              
                                                            _lifo.Remove(_lifo[_top]);
                                                            _top--;
                                                            Draw(_lf.Labyrint[_lifo[_top][0]][_lifo[_top][1]]);
                                             }
                              }
               }

               /// <summary>
               /// Prelozi vstup a nakresli dalsiu miestonst
               /// </summary>
               /// <param name="input">Vstup od uzivatela</param>
               private void TranslateAndUpdate(string? input)
               {
                              int[] answer;
                              int[] next;
                              switch (input?.ToUpper())
                              {
                                           case  "SEVER":
                                                          answer = [-1,0];
                                                          next = [_lifo[_top][0]+answer[0], _lifo[_top][1]+answer[1]];
                                                          Update(next, true); 
                                                          break;
                                           case "VYCHOD":
                                                          answer = [0, 1];
                                                          next = [_lifo[_top][0]+answer[0], _lifo[_top][1]+answer[1]];
                                                          Update(next, true); 
                                                          break;
                                           case "JUH":
                                                          answer = [1, 0];
                                                          next = [_lifo[_top][0]+answer[0], _lifo[_top][1]+answer[1]];
                                                          Update(next, true); 
                                                          break;
                                           case "ZAPAD":
                                                          answer = [0, -1];
                                                          next = [_lifo[_top][0]+answer[0], _lifo[_top][1]+answer[1]];
                                                          Update(next, true); 
                                                          break;
                                           case "NAVRAT":
                                                          Update(null,false);
                                                          break;
                                           default:
                                                          Console.WriteLine("\nZadaj korektny smer");
                                                          int i = _lf.Labyrint[_lifo[_top][0]][_lifo[_top][1]];
                                                          Draw(i);
                                                          break;
                              }
               }
}