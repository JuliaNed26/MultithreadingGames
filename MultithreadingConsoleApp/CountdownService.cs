namespace MultithreadingConsoleApp;

public class CountdownService
{
    private static ThreadLocal<int> threadLocalCounter = new (() => 0);

    public void PrintCountdown(string? startNumber)
    {
        var currentThreadName = Thread.CurrentThread.Name;
        
        int countdownNumber = 0;
        try
        {
            if (!int.TryParse(startNumber, out countdownNumber))
            {
                throw new ArgumentException("Can not parse value from console to int.", startNumber);
            }

            if (countdownNumber <= 0)
            {
                throw new ArgumentOutOfRangeException("Number for countdown should be greater than zero", startNumber);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        for (int i = countdownNumber; i > 0; i--)
        {
            Console.WriteLine($"{currentThreadName}: {i}");
            Thread.Sleep(100);
        }
    }

    public void IncreaseLocalVariable(CancellationToken ct)
    {
        var isCancelled = ct.IsCancellationRequested;
        while (!Volatile.Read(ref isCancelled))
        {
            threadLocalCounter.Value++;
            isCancelled = ct.IsCancellationRequested;
        }
        Console.WriteLine($"{Thread.CurrentThread.Name} : {threadLocalCounter.Value}");
    }
}