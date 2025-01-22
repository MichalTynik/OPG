namespace LIFO;

using System;
using System.IO;

public class LabFile
{
               int[][] _labyrint = new int[5][];

               /// <summary>
               /// Setter/Getter pre _labyrint
               /// </summary>
               /// <exception cref="ArgumentNullException"></exception>
               public int[][] Labyrint
               {
                              get => _labyrint;
                              set => _labyrint = value ?? throw new ArgumentNullException(nameof(value));
               }

               /// <summary>
               /// Konstruktor
               /// </summary>
               public LabFile()
               {
                              FileReader();
               }
               
               /// <summary>
               /// Precita a naplni _labyrint
               /// </summary>
               void FileReader()
               {
                              
                              string[] file = new string[] { };
                              int row = 0;
                              int col = 0;

                              using (StreamReader sr = new StreamReader("lab.txt"))
                              {
                                             file = sr.ReadToEnd().Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                              }
                              int[] fileInt = file.Select(i => int.Parse(i)).ToArray();
                              for (int i = 0; i < fileInt.Length; i++)
                              {
                                             if (Labyrint[row] == null)
                                             {
                                                            Labyrint[row] = new int[5]; 
                                             }

                                             Labyrint[row][col] = fileInt[i];

                                             if (col == 4)
                                             {
                                                            col = 0;
                                                            row++;
                                             }
                                             else
                                             {
                                                            col++;
                                             }
                              }
               }

               /// <summary>
               /// Vypis pre _labyrint
               /// </summary>
               /// <returns></returns>
               public override string ToString()
               {
                              string result = "";
                              foreach (var row in Labyrint)
                              {
                                             string[] rowString = row.Select(i => i.ToString()).ToArray();
                                             foreach (var str in rowString)
                                             {
                                                            result += str + " ";
                                             }
                                             result += "\n"; 
                              }
                              return result;
               }
}