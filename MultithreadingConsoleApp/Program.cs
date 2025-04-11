using System.Text;

class Program
{
    public static int _counter;
    
    static void Main()
    {
        Thread t1 = new Thread(IncrementThreadLocal);
        Thread t2 = new Thread(IncrementThreadLocal);
        
        t1.Start();
        t2.Start();
        
        t1.Join();
        t2.Join();
    }

    static void IncrementThreadLocal()
    {
        for (int i = 0; i < 5; i++)
        {
            _counter++;
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: {_counter}");
        }
    }
}