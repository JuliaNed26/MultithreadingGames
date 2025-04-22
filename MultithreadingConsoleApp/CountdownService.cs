namespace MultithreadingConsoleApp;

public class CountdownService
{
    public void PrintCountdown(string? startNumber)
    {
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


        while (Console.ReadKey().Key != ConsoleKey.Spacebar)
        { }
        for (int i = countdownNumber; i > 0; i--)
        {
            Console.WriteLine(i);
        }
    }
}