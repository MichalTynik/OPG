using Microsoft.VisualBasic;

namespace _2024_9_25
{
    /// <summary>
    /// Search
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Pocet cisel: ");
            int.TryParse(Console.ReadLine(), out int pocet);
            List<int> list = new List<int>();
            for (int i = 0; i < pocet; i++)
            {
                var random = new Random();
                list.Add(random.Next(0, 100));
            }
            foreach (var item in list)
            {
                Console.Write(item + ", ");


            }
            Console.WriteLine();
            Console.Write("Cislo ktore hladas: ");
            int.TryParse(Console.ReadLine(), out int hladane);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            //Console.WriteLine(LinearSearch(list, hladane));
            watch.Stop();
            Console.WriteLine("LinearSearch: " + watch.ElapsedMilliseconds);

        }

        //static int LinearSearch(List<int> zoznam, int hladane)
        //{
        //    int pozicia = -1;
        //    foreach (var item in zoznam)
        //    {
        //        if (item == hladane)
        //        {
        //            pozicia = zoznam.IndexOf(item);
        //        }
        //    }
        //    return pozicia;
        //}

        //static int BinarySearch(List<int> zoznam, int hladane)
        //{
        //    int od = zoznam.Min();
        //    int po = zoznam.Max();
        //    int stred = od + po / 2;
        //    if (stred == hladane)
        //    {
        //        return zoznam.IndexOf(hladane);
        //    }
        //    if (hladane > stred)
        //    {
        //        od = stred;
        //        stred = od + po / 2;
        //        if (stred == hladane)
        //        {
        //            return zoznam.IndexOf(hladane);
        //        }
        //    }
        //    else
        //    {
        //        po = stred;
        //        stred = od + po / 2;
        //        if (stred == hladane)
        //        {
        //            return zoznam.IndexOf(hladane);
        //        }
        //    }
        //}
    }
}
