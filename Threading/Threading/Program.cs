namespace Threading;

class Program
{
    public static int Kosik = 0;
    private static readonly CancellationTokenSource Cts = new();
    private static readonly Lock Padlock = new();

    private static void Main(string[] args)
    {
        Led led = new Led();
        Pocitadlo pocitadlo = new Pocitadlo();
        Pridaj pridaj = new Pridaj("Janicko");
        Pridaj pridaj2 = new Pridaj( "Marienka");
        var ct = Cts.Token;
        // Task.Run(() => pocitadlo.RunPocitadlo(ct, "prve"), ct);;
        // Task.Run(() => pocitadlo.RunPocitadlo(ct, "druhe"), ct);;
        Task.Run(() => pridaj.RunPridaj(ct), ct);
        Task.Run(() => pridaj2.RunPridaj(ct), ct);
        Console.WriteLine("Press any key to stop");
        Console.ReadKey();
        Cts.Cancel();
    }

    public static void BezchybnePridaj()
    {
        lock (Padlock)
        {
            Kosik++;
        }
    }
}

internal class Led
{
    public async Task RunLed(CancellationToken token)
    {
        try
        {
            while (!token.IsCancellationRequested)
            {
                Console.WriteLine("ON");
                await Task.Delay(1000, token);
                Console.WriteLine("OFF");
                await Task.Delay(1000, token);
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("LED operation cancelled");
        }
    }
}

class Pocitadlo
{
    public Task RunPocitadlo(CancellationToken token, string name)
    {
        try
        {
            for (int i = 0; i < 10000; i++)
            {
                if (token.IsCancellationRequested)
                    break;
                Console.WriteLine(name + ": "+i);
            }

            return Task.CompletedTask;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Task ended");
            return Task.CompletedTask;
        }
    }
}

class Pridaj(string name)
{
    public Task RunPridaj(CancellationToken token)
    {
        try
        {
            for (int i = 0; i < 10000; i++)
            {
                if (token.IsCancellationRequested)
                    break;
                Program.BezchybnePridaj();
            }

            Console.WriteLine(Program.Kosik + " " + name);
            return Task.CompletedTask;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Pridaj operation cancelled");
            return Task.CompletedTask;
        }
    }
}