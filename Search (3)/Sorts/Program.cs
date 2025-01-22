using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using Sorts;

Console.WriteLine("Kolko nahodnych cisel");
int.TryParse(Console.ReadLine(), out int pocet);
Console.WriteLine("Nahodne [N]\nVzostupne [V}\nZostupne [Z]");
string sposob = Console.ReadLine();
Random rnd = new Random();
List<int> list = new List<int>();
Stopwatch sw = new Stopwatch();

int comparisonCounter = 0; 
int assignmentCounter = 0; 


int random = rnd.Next(list.Min(), list.Max());

void ResetCounters()
{
    comparisonCounter = 0;
    assignmentCounter = 0;
}

List<int> RandomInput(int pocetLink, string sposobLink)
{
    list = new List<int>();
    switch (sposobLink)
    {
        case "N":
            for (int i = 0; i < pocetLink; i++)
            {
                list.Add(rnd.Next(0, 10000));
            }
            break;
        case "V":
            for (int i = 0; i < pocetLink; i++)
            {
                if (i==0)
                    list.Add(rnd.Next(0, 10));
                else
                    list.Add(rnd.Next(0, 10)+1);
                
            }
            break;
        case "Z":
            for (int i = 0; i < pocetLink; i++)
            {
                if (i==0)
                    list.Add(rnd.Next(0, 10));
                else
                    list.Add(rnd.Next(0, 10)-1);
            }
            break;
    }
    return list;
}

void BubleSort()
{
    int[] sorted = new int[pocet];
    list.CopyTo(sorted);
    int current;
    ResetCounters();  
    sw.Start();
    for (int i = 0; i < pocet - 1; i++)
    {
        for (int j = 0; j < pocet - i - 1; j++)
        {
            comparisonCounter++;  
            if (sorted[j] > sorted[j + 1])
            {
                current = sorted[j + 1];
                sorted[j + 1] = sorted[j];
                sorted[j] = current;
                assignmentCounter += 1;  
            }
        }
    }
    sw.Stop();
    Console.WriteLine($"BubleSort({sw.ElapsedMilliseconds}): Porovnania: {comparisonCounter}, Priradenia: {assignmentCounter}");
    Console.WriteLine("-----------------------------------------------");
    sw.Reset();
}

void SelectSort()
{
    int[] sorted = new int[pocet];
    list.CopyTo(sorted);
    int pos = 0, current;
    ResetCounters();
    sw.Start();
    for (int i = 0; i < pocet; i++)
    {
        pos = i;
        for (int j = i + 1; j < pocet; j++)
        {
            comparisonCounter++;  
            if (sorted[pos] > sorted[j])
            {
                pos = j;
            }
        }
        current = sorted[pos];
        sorted[pos] = sorted[i];
        sorted[i] = current;
        assignmentCounter += 1;  
    }
    sw.Stop();
    Console.WriteLine($"SelectSort({sw.ElapsedMilliseconds}): Porovnania: {comparisonCounter}, Priradenia: {assignmentCounter}");
    Console.WriteLine("-------------------------------------------");
    sw.Reset();
}

void InsertSort()
{
    int[] sorted = new int[pocet];
    list.CopyTo(sorted);
    int current;
    ResetCounters();
    sw.Start();
    for (int i = 0; i < pocet; i++)
    {
        if (i != 0)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                comparisonCounter++;  
                if (sorted[j] > sorted[j + 1])
                {
                    current = sorted[j + 1];
                    sorted[j + 1] = sorted[j];
                    sorted[j] = current;
                    assignmentCounter += 1;  
                }
            }
        }
    }
    sw.Stop();
    Console.WriteLine($"InsertSort({sw.ElapsedMilliseconds}): Porovnania: {comparisonCounter}, Priradenia: {assignmentCounter}");
    Console.WriteLine("-------------------------------------------");
    sw.Reset();
}

void InsertSortBinarySearch()
{
    int[] sorted = new int[pocet];
    list.CopyTo(sorted);
    ResetCounters();
    sw.Start();
    for (int i = 1; i < pocet; i++)
    {
        int x = sorted[i];
        comparisonCounter++;  
        int j = Math.Abs(Array.BinarySearch(sorted, 0, i, x) + 1);

        assignmentCounter += (i - j); 
        Array.Copy(sorted, j, sorted, j + 1, i - j);

        sorted[j] = x;
        assignmentCounter++;  
    }
    sw.Stop();
    Console.WriteLine($"InsertSortBinarySearch({sw.ElapsedMilliseconds}): Porovnania: {comparisonCounter}, Priradenia: {assignmentCounter}");
    Console.WriteLine("-------------------------------------------");
    sw.Reset();
}

void QuickSort(int left, int right)
{
    int[] sorted = new int[pocet];
    list.CopyTo(sorted);

    void QuickSortRecursive(int leftInner, int rightInner)
    {
        if (leftInner < rightInner)
        {
            int pivot = sorted[rightInner];  
            int i = leftInner - 1;

            for (int j = leftInner; j < rightInner; j++)
            {
                comparisonCounter++;  
                if (sorted[j] <= pivot)
                {
                    i++;
                    int temp = sorted[i];
                    sorted[i] = sorted[j];
                    sorted[j] = temp;
                    assignmentCounter += 1;
                }
            }

            int tempPivot = sorted[i + 1];
            sorted[i + 1] = sorted[rightInner];
            sorted[rightInner] = tempPivot;
            assignmentCounter += 1;

            int pivotIndex = i + 1;
            QuickSortRecursive(leftInner, pivotIndex - 1);
            QuickSortRecursive(pivotIndex + 1, rightInner);
        }
    }

    ResetCounters();
    sw.Start();
    QuickSortRecursive(left, right);
    sw.Stop();
    Console.WriteLine($"QuickSort({sw.ElapsedMilliseconds}): Porovnania: {comparisonCounter}, Priradenia: {assignmentCounter}");
    Console.WriteLine("-------------------------------------------");
    sw.Reset();
}

void MergeSort()
{
    int[] sorted = new int[pocet];
    list.CopyTo(sorted);

    sw.Start();
    sorted = MergeSortRecursive(sorted);
    sw.Stop();

    Console.WriteLine($"MergeSort({sw.ElapsedMilliseconds}): Porovnania: {comparisonCounter}, Priradenia: {assignmentCounter}");
    Console.WriteLine("-------------------------------------------");
    sw.Reset();

}

int[] MergeSortRecursive(int[] array)
{
    if (array.Length <= 1)
    {
        return array;
    }

    int mid = array.Length / 2;
    int[] left = new int[mid];
    int[] right = new int[array.Length - mid];

    Array.Copy(array, 0, left, 0, mid);
    Array.Copy(array, mid, right, 0, array.Length - mid);

    left = MergeSortRecursive(left);
    right = MergeSortRecursive(right);

    return Merge(left, right);
}

int[] Merge(int[] left, int[] right)
{
    int[] result = new int[left.Length + right.Length];
    int i = 0, j = 0, k = 0;

    while (i < left.Length && j < right.Length)
    {
        comparisonCounter++;  
        if (left[i] <= right[j])
        {
            result[k++] = left[i++];
        }
        else
        {
            result[k++] = right[j++];
        }
        assignmentCounter++;  
    }

    while (i < left.Length)
    {
        result[k++] = left[i++];
        assignmentCounter++;  
    }

    while (j < right.Length)
    {
        result[k++] = right[j++];
        assignmentCounter++;  
    }

    return result;
}

void RadixSort()
{
    int[] sorted = new int[pocet];
    list.CopyTo(sorted);

    sw.Start();
    int maxValue = sorted.Max();
    for (int exp = 1; maxValue / exp > 0; exp *= 10)
    {
        sorted = CountingSortForRadix(sorted, exp);
    }
    sw.Stop();

    Console.WriteLine($"RadixSort({sw.ElapsedMilliseconds}): Porovnania: {comparisonCounter}, Priradenia: {assignmentCounter}");
    Console.WriteLine("-------------------------------------------");
    sw.Reset();
}

int[] CountingSortForRadix(int[] array, int exp)
{
    int[] output = new int[array.Length];
    int[] count = new int[10];

    for (int i = 0; i < array.Length; i++)
    {
        count[(array[i] / exp) % 10]++;
        comparisonCounter++;  
    }

    for (int i = 1; i < 10; i++)
    {
        count[i] += count[i - 1];
        assignmentCounter++; 
    }

    for (int i = array.Length - 1; i >= 0; i--)
    {
        output[count[(array[i] / exp) % 10] - 1] = array[i];
        count[(array[i] / exp) % 10]--;
        assignmentCounter++;  
    }

    return output;
}

void DoTreeSort()
{
    sw.Start();
    TreeSort treeSort = new TreeSort();
    
    foreach (var VARIABLE in RandomInput(pocet, sposob))
    {
        treeSort.Insert(VARIABLE);
    }
    long counter = treeSort.Steps;
    sw.Stop();
    Console.WriteLine($"TreeSort: Pocet krokov = {counter}, Cas(ms) = {sw.ElapsedMilliseconds}");
    sw.Reset();
}

void LinearSearch()
{
    sw.Start();
    int porovnanie = 0;
    foreach (var VARIABLE in list)
    {
        porovnanie++;
        if (random == VARIABLE)
        {
            sw.Stop();
            Console.WriteLine($"LinearSearch: \nPozicia hladaneho cisla: {list.IndexOf(VARIABLE)}\nPocet porovnani: {porovnanie}\nDlzka hladania: {sw.Elapsed.Milliseconds} ");
            Console.WriteLine("-------------------------------------------------------");
            return;
        }
    }

    if (!list.Contains(random))
    {
        sw.Stop();
        Console.WriteLine($"LinearSearch: \nPozicia hladaneho cisla: -1\nPocet porovnani: {porovnanie}\nDlzka hladania: {sw.Elapsed.Milliseconds} ");
        Console.WriteLine("-------------------------------------------------------");
        sw.Reset();
    }
}

/*
void BinarySearch()
{   
    list.Sort();
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    int od = 0;
    int po = pocet - 1;
    int porovnanie = 0;

    while (od <= po)
    {
        porovnanie++;
        int stred = (od + po) / 2;
        int kontrola = list[stred].CompareTo(random);

        if (kontrola == 0)
        {
            stopwatch.Stop();
            Console.WriteLine($"BinarySearch: \nPozicia hladaneho cisla: {stred}\nPocet porovnani: {porovnanie}\nDlzka hladania: {stopwatch.ElapsedMilliseconds} ");
            return;
        }
        else if (kontrola < 0)
        {
            od = stred + 1;
        }
        else
        {
            po = stred - 1;
        }
    }

    stopwatch.Stop();
    Console.WriteLine($"BinarySearch: \nPozicia hladaneho cisla: -1\nPocet porovnani: {porovnanie}\nDlzka hladania: {stopwatch.ElapsedMilliseconds} ");
}
*/

DoTreeSort();

