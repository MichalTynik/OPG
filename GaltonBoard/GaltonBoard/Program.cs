/*import random
               pocetHodov = int(input("Zadaj pocet hodov: "))
pocetStien = int(input("Zadaj pocet stien objektu: "))
pocetKociek = int(input("Zadaj pocet kociek: "))
celkovyPocetStien = pocetStien * pocetKociek
pocetnost = [0]*celkovyPocetStien

for i in range(pocetHodov):
cislo = 0
for j in range(pocetKociek):
cislo += random.randint(1,pocetStien)
print(cislo, end=", ")
pocetnost[cislo-1] += 1 

maxPocetnost = max(pocetnost)
minPocetnost = min(pocetnost)

print()
for i in range(pocetKociek-1, celkovyPocetStien):
print(f"{i:2}: {pocetnost[i]:6}"+" "*round(pocetnost[i]/maxPocetnost)*100)+"*")*/

Console.WriteLine("Zadaj pocet guliciek: ");
int pocetG = int.Parse(Console.ReadLine());
Console.WriteLine("Zadaj pocet hladin: ");
int pocetH = int.Parse(Console.ReadLine());
int[] priehradky = new int[2*pocetH+1]; 

for (int i = 0; i < pocetG; i++)
{
               int priehradka = GaltonBoardTest(pocetH, pocetH);
               priehradky[priehradka] += 1;
}

int maxpocet = priehradky.Max();
for (int i = 0; i < 2 * pocetH + 1; i++)
{
               if (i % 2 == 1)
                              continue;
               int spaces = (int)Math.Round((double)priehradky[i] / maxpocet * 100);
               Console.WriteLine($"{i,2}: {priehradky[i],6}" + new string(' ', spaces) + "*");
}

int GaltonBoardTest(int hladina, int x)
{
               Random rnd = new Random();
               if (hladina == 0)
                              return x;
               if (rnd.Next(0, 2) == 0)
                              return GaltonBoardTest(hladina - 1, x - 1);
               else
                              return GaltonBoardTest(hladina - 1, x + 1);
}